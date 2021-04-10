using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SubsystemRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int subsystemUsedStateId = 15;
        private readonly int subsystemUnusedStateId = 16;

        private readonly int elementNewStateId = 15;

        public SubsystemRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Subsystem>> GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Where(s => s.Category != null)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.OperationPrinciple)
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
            IQueryable<Subsystem> query = dbContext.Subsystems.Where(s => s.Architecture != null)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.OperationPrinciple)
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

        public async Task<Subsystem> GetByIdPLAsync(int id)
        {
            return await dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.OperationPrinciple)
                                             .Include(s => s.Category)
                                             .Include(s => s.DCresult)
                                             .Include(s => s.MTTFdResult)
                                             .Include(s => s.PLresult)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.DC)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.MTTFdResult)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.Producer)
                                             .AsNoTracking()
                                             .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subsystem> GetByIdSILAsync(int id)
        {
            return await dbContext.Subsystems.Include(s => s.OperationPrinciple)
                                             .Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.Architecture)
                                             .Include(s => s.PFHdResult)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                             .AsNoTracking()
                                             .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ICollection<CCF>> GetCCFsForSubsystemAsync(int subsystemId)
        {
            // Getting all CCFs related to selected subsystem
            int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == subsystemId)
                                                          .Select(a => a.CCFId)
                                                          .ToArrayAsync();
            ICollection<CCF> foundCCFs = new List<CCF>();
            if (foundIds.Count() != 0)
                foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
            return foundCCFs;
        }

        // TODO: test for SIL methodics
        public async Task<int> CreateAsync(Subsystem subsystem, int userId, int safetyFunctionId)
        {
            // Assigning initial state to new record according to safetyFunctionId
            subsystem.CurrentStateId = (safetyFunctionId != 0) ? subsystemUsedStateId : subsystemUnusedStateId;

            dbContext.Attach(subsystem.TypeOfSubsystem).State = EntityState.Unchanged;
            dbContext.Attach(subsystem.OperationPrinciple).State = EntityState.Unchanged;

            subsystem.SafetyFunctionSubsystems = null;
            subsystem.SubsystemCCFs = null;

            // Setting navigation properties to null to avoid change tracking excpetion with trackig multiple entities with same id
            subsystem.DCresult = null;
            subsystem.Category = null;
            subsystem.MTTFdResult = null;
            subsystem.PLresult = null;
            subsystem.Architecture = null;
            subsystem.PFHdResult = null;
            foreach (var element in subsystem.Elements)
            {
                element.CurrentStateId = elementNewStateId;
                element.MTTFdResult = null;
                element.DC = null;
                element.Producer = null;
                element.Subsystem = null;
                element.ElementSFFs = null;
            }

            await dbContext.AddAsync(subsystem);
            await dbContext.CommitChangesAsync(userId);
            return subsystem.Id;
        }

        public async Task AddCCFsToSubsystemAsync(ICollection<CCF> CCFs, int subsystemId)
        {
            foreach (var item in CCFs)
            {
                var record = new SubsystemCCF()
                {
                    SubsystemId = subsystemId,
                    CCFId = item.Id,
                };
                await dbContext.AddAsync(record);
            }
            await dbContext.CommitChangesAsync();
        }

        public async Task UpdateSubsystemStateAsync(int subsystemId, int userId)
        {
            // Untracking all tracked entites.
            dbContext.ChangeTracker.Clear();

            var subsystem = await dbContext.Subsystems.AsNoTracking().FirstOrDefaultAsync(s => s.Id == subsystemId);
            int nextStateId = 0;

            // If selected subsystem has related record in SafetyFunctionSubsystem join tale, than subsystem is used in some safety function -> state "Used"
            if (await dbContext.SafetyFunctionSubsystems.AnyAsync(sfs => sfs.SubsystemId == subsystemId))
                nextStateId = subsystemUsedStateId;
            else
                nextStateId = subsystemUnusedStateId;

            if (subsystem.CurrentStateId == nextStateId)
                return;
            subsystem.CurrentStateId = nextStateId;
            dbContext.Update(subsystem);
            await dbContext.CommitChangesAsync(userId);
        }
    }
}
