using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Services.Implementations
{
    public class PerformanceLevelService : IPerformanceLevelService
    {
        private AppDbContext dbContext;

        public PerformanceLevelService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PerformanceLevel> GetRequiredPLAsync(S s, F f, P p)
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
            return await dbContext.PerformanceLevels.SingleOrDefaultAsync(i => i.Label == pl);
        }
    }
}
