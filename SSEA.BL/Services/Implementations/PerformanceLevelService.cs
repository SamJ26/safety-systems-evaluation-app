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
            if (s is null || f is null || p is null)
                return null;
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

            // Check whether user selected MTTFd of elements directly or should be calculated
            await CalculateMTTFdForElements(subsystem);

            // Evaluation of MTTFd
            subsystem.ResultantMTTFd = GetMTTFdForSubsystem(subsystem.Elements);

            // Evaluation of DC
            subsystem.ResultantDC = GetDCForSubsystem(subsystem.Elements);

            try
            {
                ValidateSubsystem(subsystem);
            }
            catch (Exception e)
            {
                throw e;
            }

            // Evaluation of PL
            subsystem.ResultantPL = await GetPLAsync(subsystem.Category, subsystem.ResultantMTTFd, subsystem.ResultantDC);
            if (subsystem.ResultantPL is null)
                throw new Exception("Unable to evaluate resultant PL - possible incompatibility between MTTFd, DC and selected category");
        }

        /// <summary>
        /// Method for evaluation of whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Safety function for evaluation </param>
        /// <returns> True if resultant PL is bigger than required PL, otherwise false </returns>
        public async Task<bool> EvaluateSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction)
        {
            if (safetyFunction.InputSubsystem is null)
                throw new Exception("Input subsystem is missing");
            if (safetyFunction.LogicSubsystem is null)
                throw new Exception("Logical subsystem is missing");
            if (safetyFunction.OutputSubsystem is null)
                throw new Exception("Output subsystem is missing");

            CategoryModel worstCategory = GetWorstCategory(safetyFunction);
            if (worstCategory is null)
                throw new Exception("Unable to determine the worst category");

            MTTFdModel mttfd;
            DCModel dcAvg;

            // Evalaution with upper limit values
            mttfd = await GetMTTFdForSafetyFunctionAsync(safetyFunction, true);
            if (mttfd is null)
                throw new Exception("Unable to determine MTTFd using upper limit values");
            dcAvg = await GetDCForSafetyFunctionAsync(safetyFunction, true);
            if (dcAvg is null)
                throw new Exception("Unable to determine DC using upper limit values");

            PLModel upperLimitPL = await GetPLAsync(worstCategory, mttfd, dcAvg);

            // Evaluation with lower limit values
            mttfd = await GetMTTFdForSafetyFunctionAsync(safetyFunction, false);
            if (mttfd is null)
                throw new Exception("Unable to determine MTTFd using lower limit values");
            dcAvg = await GetDCForSafetyFunctionAsync(safetyFunction, false);
            if (dcAvg is null)
                throw new Exception("Unable to determine DC using lower limit values");

            PLModel lowerLimitPL = await GetPLAsync(worstCategory, mttfd, dcAvg);

            if (upperLimitPL is null && lowerLimitPL is null)
                throw new Exception("Unable to determine resultant PL - possible incompatibility between MTTFd, DC and category");

            if (upperLimitPL is null || lowerLimitPL is null)
                safetyFunction.ResultantPL = (upperLimitPL is null) ? lowerLimitPL : upperLimitPL;
            else
                safetyFunction.ResultantPL = (upperLimitPL.CompareValue > lowerLimitPL.CompareValue) ? upperLimitPL : lowerLimitPL;

            // Check if PL result is bigger or equal to required PL
            if (safetyFunction.ResultantPL.CompareValue < safetyFunction.RequiredPL.CompareValue)
                return false;
            return true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method for calculation of MTTFd for all elements in subsystem
        /// </summary>
        /// <param name="subsystem"> Evaluated subsystem </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        private async Task CalculateMTTFdForElements(SubsystemDetailModelPL subsystem)
        {
            ICollection<MTTFdModel> mttfds = mapper.Map<ICollection<MTTFdModel>>(await dbContext.MTTFds.AsNoTracking().ToListAsync());
            foreach (var element in subsystem.Elements)
            {
                if (element.ResultantMTTFd is not null)
                    continue;
                element.Nop = (element.Dop * element.Hop * 3600) / element.Tcycles;
                element.CalculatedMTTFd = element.B10d / (0.1 * element.Nop);
                element.ResultantMTTFd = mttfds.FirstOrDefault(m => m.Min <= element.CalculatedMTTFd && element.CalculatedMTTFd <= m.Max);
            }
        }

        /// <summary>
        /// Method for selection of the worst category from used subsystems
        /// </summary>
        /// <param name="safetyFunction"> Evaluated safety function </param>
        /// <returns> The worst category from used subsystems </returns>
        private CategoryModel GetWorstCategory(SafetyFunctionDetailModelPL safetyFunction)
        {
            var worstCateogry = safetyFunction.InputSubsystem.Category;

            if (safetyFunction.Communication1Subsystem is not null)
                if (safetyFunction.Communication1Subsystem.Category.CompareValue < worstCateogry.CompareValue)
                    worstCateogry = safetyFunction.Communication1Subsystem.Category;

            if (safetyFunction.Communication2Subsystem is not null)
                if (safetyFunction.Communication2Subsystem.Category.CompareValue < worstCateogry.CompareValue)
                    worstCateogry = safetyFunction.Communication2Subsystem.Category;

            if (safetyFunction.OutputSubsystem.Category.CompareValue < worstCateogry.CompareValue)
                worstCateogry = safetyFunction.OutputSubsystem.Category;

            return worstCateogry;
        }

        /// <summary>
        /// Method for calculation of MTTFd for whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Evaluated safety function </param>
        /// <param name="upperLimit"> Information, if upper or lower limit of MTTFd range should be used for calculation </param>
        /// <returns> Calculated MTTFd </returns>
        private async Task<MTTFdModel> GetMTTFdForSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction, bool upperLimit)
        {
            double inputMttfd = (upperLimit == true) ? safetyFunction.InputSubsystem.ResultantMTTFd.Max : safetyFunction.InputSubsystem.ResultantMTTFd.Min;
            double logicMttfd = (upperLimit == true) ? safetyFunction.LogicSubsystem.ResultantMTTFd.Max : safetyFunction.LogicSubsystem.ResultantMTTFd.Min;
            double outputMttfd = (upperLimit == true) ? safetyFunction.OutputSubsystem.ResultantMTTFd.Max : safetyFunction.OutputSubsystem.ResultantMTTFd.Min;
            short? com1Mttfd = (upperLimit == true) ? safetyFunction.Communication1Subsystem?.ResultantMTTFd.Max : safetyFunction.Communication1Subsystem?.ResultantMTTFd.Min;
            short? com2Mttfd = (upperLimit == true) ? safetyFunction.Communication2Subsystem?.ResultantMTTFd.Max : safetyFunction.Communication2Subsystem?.ResultantMTTFd.Min;

            double temp = 0;
            temp += 1 / inputMttfd;
            temp += 1 / logicMttfd;
            temp += 1 / outputMttfd;
            if (com1Mttfd is not null)
                temp += 1 / (double)com1Mttfd;
            if (com2Mttfd is not null)
                temp += 1 / (double)com2Mttfd;

            var mttfdResult =  1 / temp;
            return mapper.Map<MTTFdModel>(await dbContext.MTTFds.AsNoTracking().FirstOrDefaultAsync(m => m.Max >= mttfdResult && m.Min <= mttfdResult));
        }

        /// <summary>
        /// Method for calculation of DC for whole safety function
        /// </summary>
        /// <param name="safetyFunction"> Evaluated safety function </param>
        /// <param name="upperLimit"> Information, if upper or lower limit of DC range should be used for calculation </param>
        /// <returns> Calculated DC </returns>
        private async Task<DCModel> GetDCForSafetyFunctionAsync(SafetyFunctionDetailModelPL safetyFunction, bool upperLimit = true)
        {
            double inputMttfd = (upperLimit == true) ? safetyFunction.InputSubsystem.ResultantMTTFd.Max : safetyFunction.InputSubsystem.ResultantMTTFd.Min;
            double logicMttfd = (upperLimit == true) ? safetyFunction.LogicSubsystem.ResultantMTTFd.Max : safetyFunction.LogicSubsystem.ResultantMTTFd.Min;
            double outputMttfd = (upperLimit == true) ? safetyFunction.OutputSubsystem.ResultantMTTFd.Max : safetyFunction.OutputSubsystem.ResultantMTTFd.Min;
            short? com1Mttfd = (upperLimit == true) ? safetyFunction.Communication1Subsystem?.ResultantMTTFd.Max : safetyFunction.Communication1Subsystem?.ResultantMTTFd.Min;
            short? com2Mttfd = (upperLimit == true) ? safetyFunction.Communication2Subsystem?.ResultantMTTFd.Max : safetyFunction.Communication2Subsystem?.ResultantMTTFd.Min;

            double inputDc = (upperLimit == true) ? safetyFunction.InputSubsystem.ResultantDC.Max : safetyFunction.InputSubsystem.ResultantDC.Min;
            double logicDc = (upperLimit == true) ? safetyFunction.LogicSubsystem.ResultantDC.Max : safetyFunction.LogicSubsystem.ResultantDC.Min;
            double outputDc = (upperLimit == true) ? safetyFunction.OutputSubsystem.ResultantDC.Max : safetyFunction.OutputSubsystem.ResultantDC.Min;
            short? com1Dc = (upperLimit == true) ? safetyFunction.Communication1Subsystem?.ResultantDC.Max : safetyFunction.Communication1Subsystem?.ResultantDC.Min;
            short? com2Dc = (upperLimit == true) ? safetyFunction.Communication2Subsystem?.ResultantDC.Max : safetyFunction.Communication2Subsystem?.ResultantDC.Min;

            double denominator = 0;
            double numerator = 0;

            denominator += 1 / inputMttfd;
            denominator += 1 / logicMttfd;
            denominator += 1 / outputMttfd;
            numerator += inputDc / inputMttfd;
            numerator += logicDc / logicMttfd;
            numerator += outputDc / outputMttfd;

            if (com1Mttfd is not null)
            {
                denominator += 1 / (double)com1Mttfd;
                numerator += safetyFunction.Communication1Subsystem.ResultantDC.Max / (double)com1Mttfd;
            }
            if (com2Mttfd is not null)
            {
                denominator += 1 / (double)com2Mttfd;
                numerator += safetyFunction.Communication2Subsystem.ResultantDC.Max / (double)com2Mttfd;
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
            if (subsystem.Category.MinMTTFd.CompareValue > subsystem.ResultantMTTFd.CompareValue)
                throw new Exception("Resultant value of MTTFd is not valid for given category");

            // Validation of DC
            if (subsystem.Category.MinDC.CompareValue > subsystem.ResultantDC.CompareValue)
                throw new Exception("Resultant value of DC is not valid for given category");
        }

        /// <summary>
        /// Method for validation of CCF (common caused failure)
        /// </summary>
        /// <param name="items"> Selected CCF items </param>
        /// <returns> True if sum of selected items is bigger than 65 </returns>
        private bool IsCCFValid(HashSet<CCFModel> items)
        {
            if (items == null || items.Count == 0)
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
            if (elements.Count == 1)
                return elements.ElementAt(0).ResultantMTTFd;

            // There are two elements
            return (elements.ElementAt(0).ResultantMTTFd.CompareValue > elements.ElementAt(1).ResultantMTTFd.CompareValue) ? elements.ElementAt(0).ResultantMTTFd : elements.ElementAt(1).ResultantMTTFd;
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

            // There are two elements
            return (elements.ElementAt(0).DC.CompareValue > elements.ElementAt(1).DC.CompareValue) ? elements.ElementAt(0).DC : elements.ElementAt(1).DC;
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
            // MTTFd - kratka - CompareValue = 1
            // MTTFd - stredna - CompareValue = 2
            // MTTFd - dlha - CompareValue = 3
            // DC - ziadne - CompareValue = 1
            // DC - nizke - CompareValue = 2
            // DC - stredne - CompareValue = 3
            // DC - vysoke - CompareValue = 4

            ICollection<PLModel> performanceLevels = mapper.Map<ICollection<PLModel>>(await dbContext.PerformanceLevels.AsNoTracking().ToListAsync());

            if (category.Label.Equals("B") && dc.CompareValue == 1)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("a"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 3: return null;
                }
            }
            if (category.Label.Equals("1") && dc.CompareValue == 1)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return null;
                    case 2: return null;
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                }
            }
            if (category.Label.Equals("2") && dc.CompareValue == 2)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("a"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                }
            }
            if (category.Label.Equals("2") && dc.CompareValue == 3)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("3") && dc.CompareValue == 2)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("b"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("3") && dc.CompareValue == 3)
            {
                switch (mttfd.CompareValue)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("c"));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals("d"));
                }
            }
            if (category.Label.Equals("4") && dc.CompareValue == 4)
            {
                switch (mttfd.CompareValue)
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
