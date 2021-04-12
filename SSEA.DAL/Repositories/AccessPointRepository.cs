using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class AccessPointRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int accessPointNewStateId = 6;
        private readonly int accessPointWorkInProgressStateId = 7;

        private readonly int safetyFunctionNewStateId = 10;

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

        public async Task AddExistingSafetyFunctionsAsync(ICollection<AccessPointSafetyFunction> joinEntities)
        {
            dbContext.AddRange(joinEntities);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddNewSafetyFunctionsAsync(ICollection<SafetyFunction> safetyFunctions, int accessPointId, int userId)
        {
            foreach (var safetyFunction in safetyFunctions)
            {
                safetyFunction.CurrentStateId = safetyFunctionNewStateId;

                // Explicitly setting up ids of navigation properties to avoid exception with tracking same entity more than ones
                safetyFunction.EvaluationMethodId = safetyFunction.EvaluationMethod.Id;
                safetyFunction.EvaluationMethod = null;
                safetyFunction.TypeOfFunctionId = safetyFunction.TypeOfFunction.Id;
                safetyFunction.TypeOfFunction = null;

                await dbContext.AddAsync(safetyFunction);
                await dbContext.CommitChangesAsync(userId);
                var joinEntity = new AccessPointSafetyFunction()
                {
                    AccessPointId = accessPointId,
                    SafetyFunctionId = safetyFunction.Id
                };
                await dbContext.AddAsync(joinEntity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveSafetyFunctionsAsync(ICollection<SafetyFunction> safetyFunctions, int accessPointId)
        {
            var accessPointSafetyFunctions = await dbContext.AccessPointSafetyFunctions.Where(apsf => apsf.AccessPointId == accessPointId && safetyFunctions.Select(sf => sf.Id).Contains(apsf.SafetyFunctionId)).ToListAsync();
            foreach (var item in accessPointSafetyFunctions)
            {
                item.IsRemoved = true;
            }
            dbContext.UpdateRange(accessPointSafetyFunctions);
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

        public async Task UpdateAccessPointStateAsync(int accessPointId, int userId, int stateId = 0)
        {
            // Untracking all tracked entites.
            dbContext.ChangeTracker.Clear();

            AccessPoint accessPoint = await dbContext.AccessPoints.AsNoTracking().FirstOrDefaultAsync(ap => ap.Id == accessPointId);
            int nextStateId = accessPoint.CurrentStateId;

            if (stateId != 0)
            {
                if (accessPoint.CurrentStateId == stateId)
                    return;
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
                return;
            accessPoint.CurrentStateId = nextStateId;
            dbContext.Update(accessPoint);
            await dbContext.CommitChangesAsync(userId);
        }
    }
}
