using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class AccessPointRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int accessPointNewStateId = 6;
        private readonly int accessPointWorkInProgressStateId = 7;

        public AccessPointRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AccessPoint>> GetAllAsync()
        {
            return await dbContext.AccessPoints.Include(ap => ap.CurrentState).AsNoTracking().ToListAsync();
        }

        public async Task<AccessPoint> GetByIdAsync(int id)
        {
            return await dbContext.AccessPoints.Include(ap => ap.CurrentState)
                                               .Include(ap => ap.Machine)
                                                  .ThenInclude(m => m.EvaluationMethod)
                                               .AsNoTracking()
                                               .SingleOrDefaultAsync(ap => ap.Id == id);
        }

        public async Task<ICollection<SafetyFunction>> GetSafetyFunctionsForAccessPointAsync(int acessPointId)
        {
            int[] ids = await dbContext.AccessPointSafetyFunctions.Where(apsf => apsf.AccessPointId == acessPointId)
                                                                  .Select(apsf => apsf.SafetyFunctionId)
                                                                  .ToArrayAsync();

            return await dbContext.SafetyFunctions.Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .Include(sf => sf.CurrentState)
                                                  .Where(sf => ids.Contains(sf.Id))
                                                  .AsNoTracking()
                                                  .ToListAsync();
        }

        public async Task<int> UpdateAsync(AccessPoint accessPoint, int userId)
        {
            accessPoint.Machine = null;
            accessPoint.CurrentState = null;
            dbContext.Update(accessPoint);
            await dbContext.CommitChangesAsync();
            return accessPoint.Id;
        }

        public async Task AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            AccessPointSafetyFunction entity = new()
            {
                AccessPointId = accessPointId,
                SafetyFunctionId = safetyFunctionId
            };
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            var entity = await dbContext.AccessPointSafetyFunctions.AsNoTracking().FirstOrDefaultAsync(i => i.AccessPointId == accessPointId && i.SafetyFunctionId == safetyFunctionId);
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int accessPointId, int userId)
        {
            // Removing access point
            AccessPoint acessPoint = await dbContext.AccessPoints.Where(ap => ap.Id == accessPointId).AsNoTracking().FirstOrDefaultAsync();
            acessPoint.IsRemoved = true;
            dbContext.Update(acessPoint);
            await dbContext.CommitChangesAsync(userId);

            // Removing records from AccessPointSafetyFunction join table
            var accessPointSafetyFunctions = await dbContext.AccessPointSafetyFunctions.AsNoTracking().Where(e => e.AccessPointId == accessPointId).ToListAsync();
            foreach (var item in accessPointSafetyFunctions)
            {
                item.IsRemoved = true;
            }
            dbContext.UpdateRange(accessPointSafetyFunctions);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAccessPointStateAsync(int accessPointId, int userId, int stateId = 0)
        {
            // Untracking all tracked entites.
            dbContext.ChangeTracker.Clear();

            AccessPoint accessPoint = await dbContext.AccessPoints.AsNoTracking().FirstOrDefaultAsync(ap => ap.Id == accessPointId);
            int nextStateId = accessPoint.CurrentStateId;

            if (stateId != 0)
            {
                if (accessPoint.CurrentStateId == stateId)
                    return accessPoint.MachineId;
                nextStateId = stateId;
            }
            else
            {
                // Initial state
                if (accessPoint.CurrentStateId == accessPointNewStateId)
                {
                    // If there is at least one safety function related to this access point -> moving to next state "work in progress"
                    if (await dbContext.AccessPointSafetyFunctions.AnyAsync(apsf => apsf.AccessPointId == accessPoint.Id))
                        nextStateId = accessPointWorkInProgressStateId;
                }
            }
            if (accessPoint.CurrentStateId == nextStateId)
                return accessPoint.MachineId;
            accessPoint.CurrentStateId = nextStateId;
            dbContext.Update(accessPoint);
            await dbContext.CommitChangesAsync(userId);
            return accessPoint.MachineId;
        }
    }
}
