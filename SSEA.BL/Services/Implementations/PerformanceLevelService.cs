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
using System.Text;
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

        public bool IsCCFValid(HashSet<CCFModel> items)
        {
            if (items == null)
                return false;
            uint totalCCF = 0;
            foreach (var item in items)
                totalCCF += item.Points;
            return totalCCF >= 65;
        }

        // TODO: add logic
        public bool IsSubsystemValid(SubsystemDetailModelPL subsystem)
        {
            throw new NotImplementedException();
        }

        // TODO: complete logic
        public async Task EvaluateSubsystem(SubsystemDetailModelPL subsystem)
        {
            var mttfds = mapper.Map<ICollection<MTTFdModel>>(await dbContext.MTTFds.ToListAsync());

            // Evaluating MTTFd for elements
            foreach (var element in subsystem.Elements)
            {
                if (element.B10d != 0 && element.Nop != 0 && element.MTTFdResult == null)
                {
                    element.MTTFdCounted = element.B10d / (element.Nop * 0.01);
                    element.MTTFdResult = mttfds.SingleOrDefault(m => m.Min <= element.MTTFdCounted && element.MTTFdCounted <= m.Max);
                }
            }

            // TODO: continue

        }
    }
}
