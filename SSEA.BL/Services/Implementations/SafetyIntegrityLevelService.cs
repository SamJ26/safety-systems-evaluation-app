﻿using AutoMapper;
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

        public async Task<PFHdModel> GetRequiredSILAsync(SeModel se, FrModel fr, PrModel pr, AvModel av)
        {
            int cl = fr.Value + pr.Value + av.Value;
            short sil = 0;
            if (3 <= cl && cl <= 4)
            {
                if (se.Value == 4) sil = 2;
            }
            if (5 <= cl && cl <= 7)
            {
                if (se.Value == 4) sil = 2;
            }
            if (8 <= cl && cl <= 10)
            {
                switch (se.Value)
                {
                    case 4:
                        sil = 2;
                        break;
                    case 3:
                        sil = 1;
                        break;
                }
            }
            if (11 <= cl && cl <= 13)
            {
                switch (se.Value)
                {
                    case 4:
                        sil = 3;
                        break;
                    case 3:
                        sil = 2;
                        break;
                    case 2:
                        sil = 1;
                        break;
                }
            }
            if (14 <= cl && cl <= 15)
            {
                switch (se.Value)
                {
                    case 4:
                        sil = 3;
                        break;
                    case 3:
                        sil = 3;
                        break;
                    case 2:
                        sil = 2;
                        break;
                    case 1:
                        sil = 1;
                        break;
                }
            }
            return mapper.Map<PFHdModel>(await dbContext.PFHds.FirstOrDefaultAsync(s => s.ValueSIL == sil));
        }

        public async Task EvaluateSubsystemAsync(SubsystemDetailModelSIL subsystem)
        {
            if (subsystem.Elements.Count == 0 || subsystem.Elements is null)
                throw new Exception("Subsystem has 0 elements");

            if (subsystem.SelectedCCFs.Count == 0 || subsystem.SelectedCCFs is null)
                throw new Exception("You must select items from CCF table");

            // Evaluation of SFF:
            subsystem.ResultantSFF = EvaluateSFF(subsystem.Elements);

            // Evalution of CFF from selected CCF
            subsystem.CFF = SelectCFF(subsystem.SelectedCCFs);

            // Evaluation of HFT:
            subsystem.HFT = subsystem.Architecture.HFT;

            // Evaluation of PFHd:
            subsystem.CalculatedPFHd = CalculatePFHdForSubsystem(subsystem);
            subsystem.ResultantPFHd = mapper.Map<PFHdModel>(await dbContext.PFHds.FirstOrDefaultAsync(p => p.MinPFHd <= subsystem.CalculatedPFHd && subsystem.CalculatedPFHd <= p.MaxPFHd));
            if (subsystem.ResultantPFHd is null)
                throw new Exception($"Calculation of PFHd failed - calculated value: {subsystem.CalculatedPFHd}");

            // TODO: Check if SFF meets requirements of given architecture
        }

        public async Task<bool> EvaluateSafetyFunctionAsync(SafetyFunctionDetailModelSIL safetyFunction)
        {
            if (safetyFunction.InputSubsystem is null)
                throw new Exception("Input subsystem is missing");
            if (safetyFunction.LogicSubsystem is null)
                throw new Exception("Logical subsystem is missing");
            if (safetyFunction.OutputSubsystem is null)
                throw new Exception("Output subsystem is missing");

            safetyFunction.CalculatedPFHd = CalculatePFHdForSafetyFunction(safetyFunction);
            safetyFunction.SILCL = mapper.Map<PFHdModel>(await dbContext.PFHds.FirstOrDefaultAsync(p => p.MinPFHd <= safetyFunction.CalculatedPFHd && safetyFunction.CalculatedPFHd <= p.MaxPFHd));
            if (safetyFunction.SILCL is null)
                throw new Exception($"Calculation of PFHd failed - calculated value: {safetyFunction.CalculatedPFHd}");

            if (safetyFunction.RequiredSIL.ValueSIL > safetyFunction.SILCL.ValueSIL)
                return false;
            return true;
        }

        #endregion

        #region Private methods

        private double CalculatePFHdForSafetyFunction(SafetyFunctionDetailModelSIL safetyFunction)
        {
            double temp = 0;
            temp += safetyFunction.InputSubsystem.CalculatedPFHd;
            temp += safetyFunction.LogicSubsystem.CalculatedPFHd;
            temp += safetyFunction.OutputSubsystem.CalculatedPFHd;
            if (safetyFunction.Communication1Subsystem is not null)
                temp += safetyFunction.Communication1Subsystem.CalculatedPFHd;
            if (safetyFunction.Communication2Subsystem is not null)
                temp += safetyFunction.Communication2Subsystem.CalculatedPFHd;
            return temp;
        }

        private double CalculatePFHdForSubsystem(SubsystemDetailModelSIL subsystem)
        {
            return (subsystem.Architecture.Label) switch
            {
                "A" => CalculatePFHdForArchitectureA(subsystem),
                "B" => CalculatePFHdForArchitectureB(subsystem),
                "C" => CalculatePFHdForArchitectureC(subsystem),
                "D" => CalculatePFHdForArchitectureD(subsystem),
                _ => 0,
            };
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
