using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Implementations
{
    public class SafetyIntegrityLevelService : ISafetyIntegrityLevelService
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public SafetyIntegrityLevelService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        #region Public methods

        public async Task EvaluateSubsystemAsync(SubsystemDetailModelSIL subsystem)
        {
            if (subsystem.Elements.Count == 0 || subsystem.Elements is null)
                throw new Exception("Subsystem has 0 elements");

            if (subsystem.SelectedCCFs.Count == 0 || subsystem.SelectedCCFs is null)
                throw new Exception("You must select items from CCF table");

            // Evaluation of SFF:
            subsystem.SFFresult = EvaluateSFF(subsystem.Elements);

            // Evalution of CFF from selected CCF
            subsystem.CFF = SelectCFF(subsystem.SelectedCCFs);

            // Evaluation of HFT:
            subsystem.HFT = subsystem.Architecture.HFT;

            // Evaluation of PFHd:
            subsystem.PFHdResult = await CalculatePFHd(subsystem);
        }

        #endregion

        #region Private methods

        private async Task<PFHdModel> CalculatePFHd(SubsystemDetailModelSIL subsystem)
        {
            // TODO

            return null;
        }

        private double EvaluateSFF(ICollection<ElementDetailModelSIL> elements)
        {
            // Just one element
            if (elements.Count == 1)
                return elements.ElementAt(0).SummedSFF;

            // Having two elements
            return elements.ElementAt(0).SummedSFF > elements.ElementAt(1).SummedSFF ? elements.ElementAt(1).SummedSFF : elements.ElementAt(0).SummedSFF;
        }

        private double SelectCFF(ICollection<CCFModel> items)
        {
            uint totalCCF = 0;
            foreach (var item in items)
                totalCCF += item.Points;

            if (totalCCF < 35) return 0.1;
            if (totalCCF < 65) return 0.05;
            if (totalCCF < 85) return 0.02;
            return 0.01;
        }

        #endregion
    }
}
