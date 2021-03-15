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
    }
}
