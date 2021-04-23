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
                                                              .Include(s => s.ResultantDC)
                                                              .Include(s => s.ResultantMTTFd)
                                                              .Include(s => s.ResultantPL)
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
                query = query.Where(s => s.ResultantPLId == performanceLevelId);
            return await query.ToListAsync();
        }

        public async Task<ICollection<Subsystem>> GetAllSILAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)
        {
            IQueryable<Subsystem> query = dbContext.Subsystems.Where(s => s.Architecture != null)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.OperationPrinciple)
                                                              .Include(s => s.TypeOfSubsystem)
                                                              .Include(s => s.Architecture)
                                                              .Include(s => s.ResultantPFHd)
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
                query = query.Where(s => s.ResultantPFHdId == silId);
            return await query.ToListAsync();
        }

        public async Task<Subsystem> GetByIdPLAsync(int id)
        {
            return await dbContext.Subsystems.Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.OperationPrinciple)
                                             .Include(s => s.Category)
                                             .Include(s => s.ResultantDC)
                                             .Include(s => s.ResultantMTTFd)
                                             .Include(s => s.ResultantPL)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.DC)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.ResultantMTTFd)
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
                                             .Include(s => s.ResultantPFHd)
                                             .Include(s => s.CurrentState)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.DC)
                                             .Include(s => s.Elements)
                                                .ThenInclude(e => e.Producer)
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

        public async Task<int> CreateAsync(Subsystem subsystem, int userId, int safetyFunctionId)
        {
            // Assigning initial state to new record according to safetyFunctionId
            subsystem.CurrentStateId = (safetyFunctionId != 0) ? subsystemUsedStateId : subsystemUnusedStateId;

            dbContext.Attach(subsystem.TypeOfSubsystem).State = EntityState.Unchanged;
            dbContext.Attach(subsystem.OperationPrinciple).State = EntityState.Unchanged;

            subsystem.SafetyFunctionSubsystems = null;
            subsystem.SubsystemCCFs = null;

            // Setting navigation properties to null to avoid change tracking excpetion with trackig multiple entities with same id
            subsystem.ResultantDC = null;
            subsystem.Category = null;
            subsystem.ResultantMTTFd = null;
            subsystem.ResultantPL = null;
            subsystem.Architecture = null;
            subsystem.ResultantPFHd = null;
            foreach (var element in subsystem.Elements)
            {
                element.CurrentStateId = elementNewStateId;
                element.ResultantMTTFd = null;
                element.DC = null;
                element.Producer = null;
                element.Subsystem = null;
                element.ElementSFFs = null;
            }

            await dbContext.AddAsync(subsystem);
            await dbContext.CommitChangesAsync(userId);
            return subsystem.Id;
        }

        public async Task DeleteAsync(int subsystemId, int userId)
        {
            Subsystem subsystem = await dbContext.Subsystems.Include(s => s.Elements).AsNoTracking().FirstOrDefaultAsync(s => s.Id == subsystemId);

            // Removing subsystem and related elements
            subsystem.IsRemoved = true;
            foreach (var element in subsystem.Elements)
                element.IsRemoved = true;
            dbContext.Update(subsystem);
            await dbContext.CommitChangesAsync(userId);

            // Removing records from SafetyFunctionSubsystem join table
            var safetyFunctionSubsystems = await dbContext.SafetyFunctionSubsystems.AsNoTracking().Where(sfs => sfs.SubsystemId == subsystemId).ToListAsync();
            foreach (var item in safetyFunctionSubsystems)
                item.IsRemoved = true;

            // Removing records from SubsystemCCF join table
            var subsystemCCFs = await dbContext.SubsystemCCFs.AsNoTracking().Where(sc => sc.SubsystemId == subsystemId).ToListAsync();
            foreach (var item in subsystemCCFs)
                item.IsRemoved = true;

            dbContext.UpdateRange(safetyFunctionSubsystems);
            dbContext.UpdateRange(subsystemCCFs);
            await dbContext.SaveChangesAsync();

            // Removing records from ElementSFF join table for each element in subsystem
            foreach (var element in subsystem.Elements)
            {
                var elementSFFs = await dbContext.ElementSFFs.AsNoTracking().Where(es => es.ElementId == element.Id).ToListAsync();
                foreach (var item in elementSFFs)
                    item.IsRemoved = true;
                dbContext.UpdateRange(elementSFFs);
                await dbContext.SaveChangesAsync();
            }
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
            int nextStateId = subsystem.CurrentStateId;

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
