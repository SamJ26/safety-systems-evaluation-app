using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SafetyFunctionRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int safetyFunctionNewStateId = 10;
        private readonly int safetyFunctionWorkInProgressStateId = 11;
        private readonly int safetyFunctionReadyForEvaluationStateId = 12;

        public SafetyFunctionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<SafetyFunction>> GetAllAsync(string name, int stateId, int typeOfFunctionId, int evaluationMethodId)
        {
            IQueryable<SafetyFunction> query = dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                                        .Include(sf => sf.EvaluationMethod)
                                                                        .Include(sf => sf.TypeOfFunction)
                                                                        .AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                query = query.Where(sf => sf.Name.ToLower().Contains(name));
            }
            if (stateId != 0)
                query = query.Where(sf => sf.CurrentStateId == stateId);
            if (typeOfFunctionId != 0)
                query = query.Where(sf => sf.TypeOfFunctionId == typeOfFunctionId);
            if (evaluationMethodId != 0)
                query = query.Where(m => m.EvaluationMethodId == evaluationMethodId);
            return await query.ToListAsync();
        }

        public async Task<SafetyFunction> GetByIdPLAsync(int id)
        {
            // Getting safety function without subsystems
            return await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.PLr)
                                                  .Include(sf => sf.PLresult)
                                                  .Include(sf => sf.S)
                                                  .Include(sf => sf.F)
                                                  .Include(sf => sf.P)
                                                  .AsNoTracking()
                                                  .SingleOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<SafetyFunction> GetByIdSILAsync(int id)
        {
            // Getting safety function without subsystems
            return await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.SILCL)
                                                  .Include(sf => sf.SILresult)
                                                  .Include(sf => sf.Se)
                                                  .Include(sf => sf.Fr)
                                                  .Include(sf => sf.Pr)
                                                  .Include(sf => sf.Av)
                                                  .AsNoTracking()
                                                  .SingleOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<ICollection<Subsystem>> GetSubsystemsForSafetyFunctionPLAsync(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await GetIdsOfSubsystems(safetyFunctionId);

            var subsystems = await dbContext.Subsystems.Where(s => s.CategoryId != null && subsystemIds.Contains(s.Id))
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.OperationPrinciple)
                                                       .Include(s => s.Category)
                                                       .Include(s => s.DCresult)
                                                       .Include(s => s.MTTFdResult)
                                                       .Include(s => s.PLresult)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();
            return subsystems;
        }

        public async Task<ICollection<Subsystem>> GetSubsystemsForSafetyFunctionSILAsync(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await GetIdsOfSubsystems(safetyFunctionId);

            var subsystems = await dbContext.Subsystems.Where(s => s.ArchitectureId != null && subsystemIds.Contains(s.Id))
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.OperationPrinciple)
                                                       .Include(s => s.Architecture)
                                                       .Include(s => s.PFHdResult)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();
            return subsystems;
        }

        public async Task<ICollection<Subsystem>> GetSubsystemsForSafetyFunctionAsync(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await GetIdsOfSubsystems(safetyFunctionId);

            return await dbContext.Subsystems.Where(s => subsystemIds.Contains(s.Id))
                                             .Include(s => s.TypeOfSubsystem)
                                             .Include(s => s.Category)
                                             .Include(s => s.Architecture)
                                             .AsNoTracking()
                                             .ToListAsync();
        }

        // TODO: edit to work also with SF SIL
        public async Task<int> CreateAsync(SafetyFunction safetyFunction, int userId)
        {
            safetyFunction.CurrentStateId = safetyFunctionNewStateId;
            dbContext.Attach(safetyFunction.TypeOfFunction).State = EntityState.Unchanged;
            dbContext.Attach(safetyFunction.EvaluationMethod).State = EntityState.Unchanged;
            if (safetyFunction.S != null && safetyFunction.F != null && safetyFunction.P != null)
            {
                dbContext.Attach(safetyFunction.S).State = EntityState.Unchanged;
                dbContext.Attach(safetyFunction.F).State = EntityState.Unchanged;
                dbContext.Attach(safetyFunction.P).State = EntityState.Unchanged;
            }
            if (safetyFunction.PLr is not null)
                dbContext.Attach(safetyFunction.PLr).State = EntityState.Unchanged;

            await dbContext.AddAsync(safetyFunction);
            await dbContext.CommitChangesAsync(userId);
            return safetyFunction.Id;
        }

        // TODO: edit to work also with SF SIL
        public async Task<int> UpdateAsync(SafetyFunction safetyFunction, int userId)
        {
            dbContext.Attach(safetyFunction.CurrentState).State = EntityState.Unchanged;
            dbContext.Attach(safetyFunction.TypeOfFunction).State = EntityState.Unchanged;
            dbContext.Attach(safetyFunction.EvaluationMethod).State = EntityState.Unchanged;
            if (safetyFunction.S is not null && safetyFunction.F is not null && safetyFunction.P is not null)
            {
                dbContext.Attach(safetyFunction.S).State = EntityState.Unchanged;
                dbContext.Attach(safetyFunction.F).State = EntityState.Unchanged;
                dbContext.Attach(safetyFunction.P).State = EntityState.Unchanged;
            }

            // Setting these properties to null to avoid change tracking excpetion with tracking two entities with the same id
            safetyFunction.PLr = null;
            safetyFunction.PLresult = null;

            dbContext.Update(safetyFunction);
            await dbContext.CommitChangesAsync(userId);
            return safetyFunction.Id;
        }

        public async Task DeleteAsync(int safetyFunctionId, int userId)
        {
            // Removing safety function
            SafetyFunction safetyFunction = await dbContext.SafetyFunctions.AsNoTracking().FirstOrDefaultAsync(sf => sf.Id == safetyFunctionId);
            safetyFunction.IsRemoved = true;
            dbContext.Update(safetyFunction);
            await dbContext.CommitChangesAsync(userId);

            // Removing records from AccessPointSafetyFunction join table
            var accessPointSafetyFunctions = await dbContext.AccessPointSafetyFunctions.AsNoTracking().Where(e => e.SafetyFunctionId == safetyFunctionId).ToListAsync();
            foreach (var item in accessPointSafetyFunctions)
                item.IsRemoved = true;
            dbContext.UpdateRange(accessPointSafetyFunctions);

            // Removing records from SafetyFunctionSusystem join table
            var safetyFunctionSubsystems = await dbContext.SafetyFunctionSubsystems.AsNoTracking().Where(e => e.SafetyFunctionId == safetyFunctionId).ToListAsync();
            foreach (var item in safetyFunctionSubsystems)
                item.IsRemoved = true;
            dbContext.UpdateRange(safetyFunctionSubsystems);

            await dbContext.SaveChangesAsync();
        }

        public async Task AddSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            var entity = new SafetyFunctionSubsystem()
            {
                SafetyFunctionId = safetyFunctionId,
                SubsystemId = subsystemId,
            };
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            var entity = await dbContext.SafetyFunctionSubsystems.AsNoTracking().FirstOrDefaultAsync(i => i.SafetyFunctionId == safetyFunctionId && i.SubsystemId == subsystemId);
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateSafetyFunctionStateAsync(int safetyFunctionId, int userId, int stateId = 0)
        {
            // Untracking all tracked entites.
            dbContext.ChangeTracker.Clear();

            var safetyFunction = await dbContext.SafetyFunctions.AsNoTracking().FirstOrDefaultAsync(sf => sf.Id == safetyFunctionId);
            int nextStateId = safetyFunction.CurrentStateId;

            if (stateId != 0)
            {
                if (safetyFunction.CurrentStateId == stateId)
                    return;
                nextStateId = stateId;
            }
            else
            {
                // Current state == Initial state
                if (safetyFunction.CurrentStateId == safetyFunctionNewStateId)
                {
                    // If there is at least one subsystem than move to state "work in progress"
                    if (await dbContext.SafetyFunctionSubsystems.AnyAsync(sfs => sfs.SafetyFunctionId == safetyFunctionId))
                        nextStateId = safetyFunctionWorkInProgressStateId;
                }
                // Current state == Work in progress state
                else if (safetyFunction.CurrentStateId == safetyFunctionWorkInProgressStateId)
                {
                    // Checking if safety function has input and output subsystem
                    if (await IsReadyForEvaluation(safetyFunctionId))
                        nextStateId = safetyFunctionReadyForEvaluationStateId;
                }
                // Current state == Ready for evaluation state
                else if (safetyFunction.CurrentStateId == safetyFunctionReadyForEvaluationStateId)
                {
                    // Checking if safety function has input and output subsystem
                    if (await IsReadyForEvaluation(safetyFunctionId))
                        return;
                    // If safety function has not input and output subsystems at this state, than we move state back to "work in progress" state
                    nextStateId = safetyFunctionWorkInProgressStateId;
                }
            }
            if (safetyFunction.CurrentStateId == nextStateId)
                return;
            safetyFunction.CurrentStateId = nextStateId;
            dbContext.Update(safetyFunction);
            await dbContext.CommitChangesAsync(userId);
        }

        private async Task<bool> IsReadyForEvaluation(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                                         .Select(a => a.SubsystemId)
                                                                         .ToArrayAsync();

            var subsystems = await dbContext.Subsystems.Where(s => subsystemIds.Contains(s.Id))
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .AsNoTracking()
                                                       .ToListAsync();
            if (subsystems.Count < 2)
                return false;

            int inputSubsystemId = 1;
            int outputSubsystemId = 2;
            bool inputSubsystem = false;
            bool outputSubsystem = false;

            // Checking if safety function has input and output subsystem
            foreach (var subsystem in subsystems)
            {
                if (subsystem.TypeOfSubsystemId == inputSubsystemId)
                    inputSubsystem = true;
                if (subsystem.TypeOfSubsystemId == outputSubsystemId)
                    outputSubsystem = true;
            }
            return inputSubsystem && outputSubsystem;
        }

        /// <summary>
        /// Method which returns ids of all subsystems which are related to safety function specified by input parameter safetyFunctionId
        /// </summary>
        /// <param name="safetyFunctionId"> Selected safety function </param>
        /// <returns> Ids as array of integers </returns>
        private async Task<int[]> GetIdsOfSubsystems(int safetyFunctionId)
        {
            return await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                           .Select(a => a.SubsystemId)
                                                           .ToArrayAsync();
        }
    }
}
 