using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SubsystemRepository
    {
        private readonly AppDbContext dbContext;

        public SubsystemRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Subsystem>> GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.Category)
                                                              .Include(s => s.DCresult)
                                                              .Include(s => s.MTTFdResult)
                                                              .Include(s => s.PLresult)
                                                              .Include(s => s.CurrentState);
            if (stateId != 0)
                query = query.Where(s => s.CurrentStateId == stateId);
            if (typeOfSubsystemId != 0)
                query = query.Where(s => s.TypeOfSubsystemId == typeOfSubsystemId);
            if (operationPrincipleId != 0)
                query = query.Where(s => s.OperationPrincipleId == operationPrincipleId);
            if (categoryId != 0)
                query = query.Where(s => s.CategoryId == categoryId);
            if (performanceLevelId != 0)
                query = query.Where(s => s.PLresultId == performanceLevelId);
            return await query.ToListAsync();
        }

        public async Task<ICollection<Subsystem>> GetAllSILAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.Architecture)
                                                              .Include(s => s.PFHdResult)
                                                              .Include(s => s.CurrentState);
            if (stateId != 0)
                query = query.Where(s => s.CurrentStateId == stateId);
            if (typeOfSubsystemId != 0)
                query = query.Where(s => s.TypeOfSubsystemId == typeOfSubsystemId);
            if (operationPrincipleId != 0)
                query = query.Where(s => s.OperationPrincipleId == operationPrincipleId);
            if (architectureId != 0)
                query = query.Where(s => s.ArchitectureId == architectureId);
            if (silId != 0)
                query = query.Where(s => s.PFHdResultId == silId);
            return await query.ToListAsync();
        }
    }
}
