using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Implementations
{
    public class PerformanceLevelService : IPerformanceLevelService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public PerformanceLevelService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #region Public methods

        /// <summary>
        /// Method for evaluation of required performance level
        /// </summary>
        /// <param name="s"> Selected severity of injury </param>
        /// <param name="f"> Selected frequency of exposure </param>
        /// <param name="p"> Selected probability of avoiding injury </param>
        /// <returns> Determined performance level </returns>
        public async Task<PLModel> GetRequiredPLAsync(SModel s, FModel f, PModel p)
        {
            string pl = (s.Value, f.Value, p.Value) switch
            {
                ("S1", "F1", "P1") => "a",
                ("S1", "F1", "P2") => "b",
                ("S1", "F2", "P1") => "b",
                ("S1", "F2", "P2") => "c",
                ("S2", "F1", "P1") => "c",
                ("S2", "F1", "P2") => "d",
                ("S2", "F2", "P1") => "d",
                _ => "e",
            };
            return mapper.Map<PLModel>(await dbContext.PerformanceLevels.Where(i => i.Label == pl).AsNoTracking().FirstOrDefaultAsync());
        }

        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        public async Task EvaluateSubsystemAsync(SubsystemDetailModelPL subsystem)
        {
            // Evaluation of CCF
            subsystem.ValidCCF = IsCCFValid(subsystem.SelectedCCFs);

            // Evaluation of MTTFd
            subsystem.MTTFdResult = GetMTTFdForSubsystem(subsystem.Elements);

            // Evaluation of DC
            subsystem.DCresult = GetDCForSubsystem(subsystem.Elements);

            try
            {
                ValidateSubsystem(subsystem);
            }
            catch (Exception e)
            {
                throw e;
            }

            // Evaluation of PL
            subsystem.PLresult = await GetPLAsync(subsystem.Category, subsystem.MTTFdResult, subsystem.DCresult);
        }

        // TODO: complete implementation
        /// <summary>
        /// Method for evaluation of whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Safety function for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        public async Task EvaluateSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction)
        {
            if (safetyFunction.InputSubsystem is null)
                throw new Exception("Missing input subsystem");
            if (safetyFunction.LogicSubsystem is null)
                throw new Exception("Missing logical subsystem");
            if (safetyFunction.OutputSubsystem is null)
                throw new Exception("Missing output subsystem");

            CategoryModel worstCategory = GetWorstCategory(safetyFunction);
            if (worstCategory is null)
                throw new Exception("Unable to determine the worst category");

            MTTFdModel mttfd;
            DCModel dcAvg;

            // Evalaution with upper limit values
            mttfd = await GetMTTFdForSafetyFunctionAsync(safetyFunction, true);
            if (mttfd is null)
                throw new Exception("Unable to determine MTTFd using upper limit value");
            dcAvg = await GetDCForSafetyFunctionAsync(safetyFunction, true);
            if (dcAvg is null)
                throw new Exception("Unable to determine DC using upper limit value");

            PLModel upperLimitPL = await GetPLAsync(worstCategory, mttfd, dcAvg);
            if (upperLimitPL is null)
                throw new Exception("Unable to determine resultant PL using upper limit value");

            // Evaluation with lower limit values
            mttfd = await GetMTTFdForSafetyFunctionAsync(safetyFunction, false);
            if (mttfd is null)
                throw new Exception("Unable to determine MTTFd using lower limit value");
            dcAvg = await GetDCForSafetyFunctionAsync(safetyFunction, false);
            if (dcAvg is null)
                throw new Exception("Unable to determine DC using lower limit value");

            PLModel lowerLimitPL = await GetPLAsync(worstCategory, mttfd, dcAvg);
            if (lowerLimitPL is null)
                throw new Exception("Unable to determine resultant PL using lower limit value");

            safetyFunction.PLresult = (upperLimitPL.Id > lowerLimitPL.Id) ? upperLimitPL : lowerLimitPL;

            // Check if PL result is bigger or equal to required PL
            if (safetyFunction.PLresult.Id < safetyFunction.PLr.Id)
                throw new Exception($"Resultant PL is not big enough! [Required PL = {safetyFunction.PLr.Label}] > [Resultant PL = {safetyFunction.PLresult.Label}]");
        }

        #endregion

        #region Private methods

        private CategoryModel GetWorstCategory(SafetyFunctionDetailModelPL safetyFunction)
        {
            var categories = new List<CategoryModel>();
            categories.Add(safetyFunction.InputSubsystem.Category);
            categories.Add(safetyFunction.LogicSubsystem.Category);
            categories.Add(safetyFunction.OutputSubsystem.Category);
            if (safetyFunction.Communication1Subsystem.Category is not null)
                categories.Add(safetyFunction.Communication1Subsystem.Category);
            if (safetyFunction.Communication2Subsystem.Category is not null)
                categories.Add(safetyFunction.Communication2Subsystem.Category);
            int minId = categories.Min(c => c.Id);
            return categories.First(c => c.Id == minId);
        }

        private async Task<MTTFdModel> GetMTTFdForSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction, bool upperLimit)
        {
            double temp = 0;
            if (upperLimit)
            {
                temp += 1 / safetyFunction.InputSubsystem.MTTFdResult.Max;
                temp += 1 / safetyFunction.LogicSubsystem.MTTFdResult.Max;
                temp += 1 / safetyFunction.OutputSubsystem.MTTFdResult.Max;

                var com1MTTFd = safetyFunction.Communication1Subsystem?.MTTFdResult.Max;
                if (com1MTTFd is not null)
                    temp += 1 / (double)com1MTTFd;

                var com2MTTFd = safetyFunction.Communication2Subsystem?.MTTFdResult.Max;
                if (com2MTTFd is not null)
                    temp += 1 / (double)com2MTTFd;
            }
            else
            {
                temp += 1 / safetyFunction.InputSubsystem.MTTFdResult.Min;
                temp += 1 / safetyFunction.LogicSubsystem.MTTFdResult.Min;
                temp += 1 / safetyFunction.OutputSubsystem.MTTFdResult.Min;

                var com1MTTFd = safetyFunction.Communication1Subsystem?.MTTFdResult.Min;
                if (com1MTTFd is not null)
                    temp += 1 / (double)com1MTTFd;

                var com2MTTFd = safetyFunction.Communication2Subsystem?.MTTFdResult.Min;
                if (com2MTTFd is not null)
                    temp += 1 / (double)com2MTTFd;
            }
            var mttfdResult =  1 / temp;
            return mapper.Map<MTTFdModel>(await dbContext.MTTFds.AsNoTracking().FirstOrDefaultAsync(m => m.Max >= mttfdResult && m.Min <= mttfdResult));
        }

        private async Task<DCModel> GetDCForSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction, bool upperLimit = true)
        {
            double denominator = 0;
            double numerator = 0;
            if (upperLimit)
            {
                denominator += 1 / safetyFunction.InputSubsystem.MTTFdResult.Max;
                denominator += 1 / safetyFunction.LogicSubsystem.MTTFdResult.Max;
                denominator += 1 / safetyFunction.OutputSubsystem.MTTFdResult.Max;
                numerator += safetyFunction.InputSubsystem.DCresult.Max / safetyFunction.InputSubsystem.MTTFdResult.Max;
                numerator += safetyFunction.LogicSubsystem.DCresult.Max / safetyFunction.LogicSubsystem.MTTFdResult.Max;
                numerator += safetyFunction.OutputSubsystem.DCresult.Max / safetyFunction.OutputSubsystem.MTTFdResult.Max;

                var com1MTTFd = safetyFunction.Communication1Subsystem?.MTTFdResult.Max;
                if (com1MTTFd is not null)
                {
                    denominator += 1 / (double)com1MTTFd;
                    numerator += safetyFunction.Communication1Subsystem.DCresult.Max / safetyFunction.Communication1Subsystem.MTTFdResult.Max;
                }
                var com2MTTFd = safetyFunction.Communication2Subsystem?.MTTFdResult.Max;
                if (com2MTTFd is not null)
                {
                    denominator += 1 / (double)com2MTTFd;
                    numerator += safetyFunction.Communication2Subsystem.DCresult.Max / safetyFunction.Communication2Subsystem.MTTFdResult.Max;
                }
            }
            else
            {
                denominator += 1 / safetyFunction.InputSubsystem.MTTFdResult.Min;
                denominator += 1 / safetyFunction.LogicSubsystem.MTTFdResult.Min;
                denominator += 1 / safetyFunction.OutputSubsystem.MTTFdResult.Min;
                numerator += safetyFunction.InputSubsystem.DCresult.Min / safetyFunction.InputSubsystem.MTTFdResult.Min;
                numerator += safetyFunction.LogicSubsystem.DCresult.Min / safetyFunction.LogicSubsystem.MTTFdResult.Min;
                numerator += safetyFunction.OutputSubsystem.DCresult.Min / safetyFunction.OutputSubsystem.MTTFdResult.Min;

                var com1MTTFd = safetyFunction.Communication1Subsystem?.MTTFdResult.Min;
                if (com1MTTFd is not null)
                {
                    denominator += 1 / (double)com1MTTFd;
                    numerator += safetyFunction.Communication1Subsystem.DCresult.Min / safetyFunction.Communication1Subsystem.MTTFdResult.Min;
                }
                var com2MTTFd = safetyFunction.Communication2Subsystem?.MTTFdResult.Min;
                if (com2MTTFd is not null)
                {
                    denominator += 1 / (double)com2MTTFd;
                    numerator += safetyFunction.Communication2Subsystem.DCresult.Min / safetyFunction.Communication2Subsystem.MTTFdResult.Min;
                }
            }
            double dcResult = numerator / denominator;
            return mapper.Map<DCModel>(await dbContext.DCs.AsNoTracking().FirstOrDefaultAsync(d => d.Max >= dcResult && d.Min <= dcResult));
        }

        /// <summary>
        /// Method which validates subsystem by comparing evaluated values with allowed ones
        /// </summary>
        /// <param name="subsystem"> Validated subsystem </param>
        private void ValidateSubsystem(SubsystemDetailModelPL subsystem)
        {
            // Comparing number of elements (must be the same)
            if (subsystem.Elements.Count != subsystem.Category.Channels)
                throw new Exception("Number of elements must be equal to number of channels in given category!");

            // Validation of CCF
            if (subsystem.ValidCCF == false && subsystem.Category.RelevantCCF)
                throw new Exception("CCF is not valid!");

            // Validation of MTTFd
            if (subsystem.Category.MinMTTFd.Min > subsystem.MTTFdResult.Min)
                throw new Exception("Resultant value of MTTFd is not valid for given category");

            // Validation of DC
            if (subsystem.Category.MinDC.Min > subsystem.DCresult.Min)
                throw new Exception("Resultant value of DC is not valid for given category");
        }

        /// <summary>
        /// Method for validation of CCF (common caused failure)
        /// </summary>
        /// <param name="items"> Selected CCF items </param>
        /// <returns> True if sum of selected items is bigger than 65 </returns>
        private bool IsCCFValid(HashSet<CCFModel> items)
        {
            if (items == null)
                return false;
            uint totalCCF = 0;
            foreach (var item in items)
                totalCCF += item.Points;
            return totalCCF >= 65;
        }

        /// <summary>
        /// Method for determination of MTTFd for whole subsystem
        /// Resultant value is the worse of the used elements
        /// </summary>
        /// <param name="elements"> Elements used in subsystem </param>
        /// <returns> Determined MTTFd </returns>
        private MTTFdModel GetMTTFdForSubsystem(ICollection<ElementDetailModelPL> elements)
        {
            // There is just one element
            if (elements.Count == 1 || elements is null)
                return elements.ElementAt(0).MTTFdResult;
            
            // There are two same elements
            MTTFdModel mttfd1 = elements.ElementAt(0).MTTFdResult;
            MTTFdModel mttfd2 = elements.ElementAt(1).MTTFdResult;

            if (mttfd1.Max == mttfd2.Max)
                return mttfd1;

            if (mttfd1.Max > mttfd2.Max)
                return mttfd2;
            return mttfd1;
        }

        /// <summary>
        /// Method for determination of DC for whole subsystem
        /// Resultant value is the worse of the used elements
        /// </summary>
        /// <param name="elements"> Elements used in subsystem </param>
        /// <returns> Determined DC </returns>
        private DCModel GetDCForSubsystem(ICollection<ElementDetailModelPL> elements)
        {
            // There is just one element
            if (elements.Count == 1)
                return elements.ElementAt(0).DC;

            // There are two same elements
            DCModel dc1 = elements.ElementAt(0).DC;
            DCModel dc2 = elements.ElementAt(1).DC;

            if (dc1.Max == dc2.Max)
                return dc1;

            if (dc1.Max > dc2.Max)
                return dc2;
            return dc1;
        }

        /// <summary>
        /// Method for evaluation of performance level according to table in norm 13849-1
        /// </summary>
        /// <param name="category"> Category of subsystem / safety function </param>
        /// <param name="mttfd"> MMTFd of subsystem / safety function </param>
        /// <param name="dc"> DC of subsystem / safety function </param>
        /// <returns> Determined PL </returns>
        private async Task<PLModel> GetPLAsync(CategoryModel category, MTTFdModel mttfd, DCModel dc)
        {
            // IDs of records:
            // MTTFd - kratka - 1
            // MTTFd - stredna - 2
            // MTTFd - dlha - 3
            // DC - ziadne - 1
            // DC - nizke - 2
            // DC - stredne - 3
            // DC - vysoke - 4

            ICollection<PLModel> performanceLevels = mapper.Map<ICollection<PLModel>>(await dbContext.PerformanceLevels.AsNoTracking().ToListAsync());

            if (category.Label.Equals("B") && dc.Id == 1)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("a"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 3: return null;
                }
            }
            if (category.Label.Equals("1") && dc.Id == 1)
            {
                switch (mttfd.Id)
                {
                    case 1: return null;
                    case 2: return null;
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                }
            }
            if (category.Label.Equals("2") && dc.Id == 2)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("a"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                }
            }
            if (category.Label.Equals("2") && dc.Id == 3)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("3") && dc.Id == 2)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("3") && dc.Id == 3)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("4") && dc.Id == 4)
            {
                switch (mttfd.Id)
                {
                    case 1: return null;
                    case 2: return null;
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("e"));
                }
            }
            return null;
        }

        #endregion
    }
}
