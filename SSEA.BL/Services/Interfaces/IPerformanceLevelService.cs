using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Interfaces
{
    public interface IPerformanceLevelService
    {
        Task<PerformanceLevel> GetRequiredPLAsync(S s, F f, P p);
        bool IsCCFValid(HashSet<CCFModel> items);
        bool IsSubsystemValid(SubsystemDetailModelPL subsystem);
        Task EvaluateSubsystem(SubsystemDetailModelPL subsystem);
    }
}
