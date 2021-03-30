using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
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

        /// <summary>
        /// Method for determination of required performance level
        /// </summary>
        /// <param name="s"> Selected severity of injury </param>
        /// <param name="f"> Selected frequency of exposure </param>
        /// <param name="p"> Selected probability of avoiding injury </param>
        /// <returns> Id of record which represents determined value </returns>
        public async Task<int> GetRequiredPLAsync(S s, F f, P p)
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
            return await dbContext.PerformanceLevels.Where(i => i.Label == pl).Select(i => i.Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Method for evaluation of subsystem's properties using data of elements
        /// </summary>
        /// <param name="subsystem"> Subsystem for evaluation </param>
        /// <returns> Method interacts with database so it returns async task </returns>
        public async Task EvaluateSubsystem(SubsystemDetailModelPL subsystem)
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
            if (elements.Count == 1)
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

            if (category.Label.Equals('B') && dc.Id == 1)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('a'));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('b'));
                    case 3: return null;
                }
            }
            if (category.Label.Equals('1') && dc.Id == 1)
            {
                switch (mttfd.Id)
                {
                    case 1: return null;
                    case 2: return null;
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('c'));
                }
            }
            if (category.Label.Equals('2') && dc.Id == 2)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('a'));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('b'));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('c'));
                }
            }
            if (category.Label.Equals('2') && dc.Id == 3)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('b'));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('c'));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('d'));
                }
            }
            if (category.Label.Equals('3') && dc.Id == 2)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('b'));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('c'));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('d'));
                }
            }
            if (category.Label.Equals('3') && dc.Id == 3)
            {
                switch (mttfd.Id)
                {
                    case 1: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('c'));
                    case 2: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('d'));
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('d'));
                }
            }
            if (category.Label.Equals('4') && dc.Id == 4)
            {
                switch (mttfd.Id)
                {
                    case 1: return null;
                    case 2: return null;
                    case 3: return performanceLevels.FirstOrDefault(pl => pl.Label.Equals('e'));
                }
            }
            return null;
        }
    }
}
