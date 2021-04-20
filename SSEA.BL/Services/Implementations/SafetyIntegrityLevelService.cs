using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (subsystem.PFHdResult is null)
                throw new Exception("Calculation of PFHd failed");

            // TODO: Check if SFF meets requirements of given architecture
        }

        #endregion

        #region Private methods

        private async Task<PFHdModel> CalculatePFHd(SubsystemDetailModelSIL subsystem)
        {
            double pfhd = (subsystem.Architecture.Label) switch
            {
                "A" => CalculatePFHdForArchitectureA(subsystem),
                "B" => CalculatePFHdForArchitectureB(subsystem),
                "C" => CalculatePFHdForArchitectureC(subsystem),
                "D" => CalculatePFHdForArchitectureD(subsystem),
                _ => 0,
            };
            if (pfhd == 0)
                return null;
            return mapper.Map<PFHdModel>(await dbContext.PFHds.FirstOrDefaultAsync(p => p.MinPFHd <= pfhd && pfhd <= p.MaxPFHd));
        }

        private double CalculatePFHdForArchitectureA(SubsystemDetailModelSIL subsystem) => (0.1 * subsystem.Elements.ElementAt(0).C) / subsystem.Elements.ElementAt(0).B10d;

        private double CalculatePFHdForArchitectureB(SubsystemDetailModelSIL subsystem)
        {
            double lambdaDe1 = (0.1 * subsystem.Elements.ElementAt(0).C) / subsystem.Elements.ElementAt(0).B10d;
            double lambdaDe2 = (0.1 * subsystem.Elements.ElementAt(1).C) / subsystem.Elements.ElementAt(1).B10d;
            double beta = subsystem.CFF;
            return (1 - beta) * (1 - beta) * lambdaDe1 * lambdaDe2 * subsystem.T1 + beta * (lambdaDe1 + lambdaDe2) / 2;
        }

        private double CalculatePFHdForArchitectureC(SubsystemDetailModelSIL subsystem)
        {
            double lambdaDe1 = (0.1 * subsystem.Elements.ElementAt(0).C) / subsystem.Elements.ElementAt(0).B10d;
            double dc = (double)subsystem.Elements.ElementAt(0).DC.Min / 100;
            return lambdaDe1 * (1 - dc);
        }

        private double CalculatePFHdForArchitectureD(SubsystemDetailModelSIL subsystem)
        {
            double lambdaDe1 = (0.1 * subsystem.Elements.ElementAt(0).C) / subsystem.Elements.ElementAt(0).B10d;
            double lambdaDe2 = (0.1 * subsystem.Elements.ElementAt(1).C) / subsystem.Elements.ElementAt(1).B10d;
            double dc1 = (double)subsystem.Elements.ElementAt(0).DC.Min / 100;
            double dc2 = (double)subsystem.Elements.ElementAt(1).DC.Min / 100;
            double beta = subsystem.CFF;
            return (1 - beta) * (1 - beta) * ((lambdaDe1 * lambdaDe2 * (dc1 + dc2)) * subsystem.T2 / 2 + (lambdaDe1 * lambdaDe2 * (2 - dc1 - dc2)) * subsystem.T1 / 2) + beta * (lambdaDe1 + lambdaDe2) / 2;
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
