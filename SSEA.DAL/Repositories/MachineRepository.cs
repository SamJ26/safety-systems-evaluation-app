using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class MachineRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int machineNewStateId = 1;
        private readonly int machineWorkInProgressStateId = 2;
        private readonly int machineLogicSelectedStateId = 3;
        private readonly int machineEvaluatedValidStateId = 4;
        private readonly int machineEvaluatedInvalidStateId = 5;
        private readonly int machineModifiedStateId = 6;

        private readonly int accessPointNewStateId = 7;

        public MachineRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Machine machine, int userId)
        {
            // Assigning initial state to machine and its access points
            machine.CurrentStateId = machineNewStateId;
            machine.AccessPoints.AsParallel().ForAll(accessPoint => accessPoint.CurrentStateId = accessPointNewStateId);

            // Attaching existing related models to change tracker
            dbContext.Attach(machine.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(machine.MachineType).State = EntityState.Unchanged;
            dbContext.Attach(machine.Producer).State = EntityState.Unchanged;

            await dbContext.AddAsync(machine);
            await dbContext.CommitChangesAsync(userId);
            return machine.Id;
        }

        public async Task AddNormsToMachineAsync(ICollection<Norm> norms, int machineId)
        {
            foreach (var norm in norms)
            {
                var machineNorm = new MachineNorm()
                {
                    NormId = norm.Id,
                    MachineId = machineId,
                };
                await dbContext.AddAsync(machineNorm);
            }
            await dbContext.CommitChangesAsync();
        }

        public async Task<ICollection<Machine>> GetAllAsync(string machineName, int stateId, int machineTypeId, int evaluationMethodId, int producerId)
        {
            IQueryable<Machine> query = dbContext.Machines.Include(m => m.CurrentState)
                                                          .Include(m => m.EvaluationMethod)
                                                          .Include(m => m.MachineType)
                                                          .Include(m => m.Producer)
                                                          .Include(m => m.TypeOfLogic)
                                                          .AsNoTracking();
            if (!string.IsNullOrEmpty(machineName))
            {
                machineName = machineName.ToLower();
                query = query.Where(m => m.Name.ToLower().Contains(machineName));
            }
            if (stateId != 0)
                query = query.Where(m => m.CurrentStateId == stateId);
            if (machineTypeId != 0)
                query = query.Where(m => m.MachineTypeId == machineTypeId);
            if (evaluationMethodId != 0)
                query = query.Where(m => m.EvaluationMethodId == evaluationMethodId);
            if (producerId != 0)
                query = query.Where(m => m.ProducerId == producerId);
            return await query.ToListAsync();
        }

        public async Task<Machine> GetByIdAsync(int id)
        {
            return await dbContext.Machines.Include(m => m.EvaluationMethod)
                                           .Include(m => m.MachineType)
                                           .Include(m => m.Producer)
                                           .Include(m => m.TypeOfLogic)
                                           .Include(m => m.CurrentState)
                                           .Include(m => m.AccessPoints)
                                             .ThenInclude(ap => ap.CurrentState)
                                           .AsNoTracking()
                                           .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ICollection<Norm>> GetNormsForMachineAsync(int machineId)
        {
            int[] ids = await dbContext.MachineNorms.Where(mn => mn.MachineId == machineId)
                                                    .Select(mn => mn.NormId)
                                                    .ToArrayAsync();

            return await dbContext.Norms.Where(n => ids.Contains(n.Id))
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public async Task RemoveNormAsync(int machineId, int normId)
        {
            var entity = await dbContext.MachineNorms.Where(mn => mn.MachineId == machineId && mn.NormId == normId).FirstOrDefaultAsync();
            dbContext.MachineNorms.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Machine machine, int userId)
        {
            for (int i = 0; i < machine.AccessPoints.Count; i++)
            {
                var accessPoint = machine.AccessPoints.ElementAt(i);

                // Removing current state properties from access points to avoid exception with tracking many entities with the same id
                accessPoint.CurrentState = null;

                // For new access points assign initial state and attach to change tracker with added state
                if (accessPoint.Id == 0)
                {
                    accessPoint.CurrentStateId = accessPointNewStateId;
                    dbContext.Attach(accessPoint).State = EntityState.Added;
                }
                else
                    dbContext.Attach(accessPoint).State = EntityState.Unchanged;
            }
            dbContext.Attach(machine.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(machine.MachineType).State = EntityState.Unchanged;
            dbContext.Attach(machine.Producer).State = EntityState.Unchanged;
            dbContext.Attach(machine.CurrentState).State = EntityState.Unchanged;
            machine.TypeOfLogic = null;
            dbContext.Update(machine);
            await dbContext.CommitChangesAsync(userId);
            return machine.Id;
        }

        public async Task DeleteAsync(int machineId, int userId)
        {
            // Removing machine and related access points
            Machine machine = await dbContext.Machines.Include(m => m.AccessPoints).AsNoTracking().SingleOrDefaultAsync(m => m.Id == machineId);
            machine.IsRemoved = true;
            foreach (var accessPoint in machine.AccessPoints)
            {
                accessPoint.IsRemoved = true;

                // Removing records from AccessPointSafetyFunction join table
                var accessPointSafetyFunctions = await dbContext.AccessPointSafetyFunctions.AsNoTracking().Where(e => e.AccessPointId == accessPoint.Id).ToListAsync();
                foreach (var item in accessPointSafetyFunctions)
                {
                    item.IsRemoved = true;
                }
                dbContext.UpdateRange(accessPointSafetyFunctions);
                await dbContext.SaveChangesAsync();
            }
            dbContext.Update(machine);
            await dbContext.CommitChangesAsync(userId);

            // Removing records from MachineNorm join table
            var machineNorms = await dbContext.MachineNorms.AsNoTracking().Where(mn => mn.MachineId == machineId).ToListAsync();
            foreach (var item in machineNorms)
            {
                item.IsRemoved = true;
            }
            dbContext.UpdateRange(machineNorms);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateMachineStateAsync(int machineId, int userId, int stateId = 0, bool accessPointsCountChanged = false)
        {
            // Untracking all tracked entites.
            dbContext.ChangeTracker.Clear();

            Machine machine = await dbContext.Machines.Include(m => m.AccessPoints).AsNoTracking().FirstOrDefaultAsync(m => m.Id == machineId);
            int nextStateId = machine.CurrentStateId;

            if (stateId != 0)
            {
                if (machine.CurrentStateId == stateId)
                    return;
                nextStateId = stateId;
            }
            else
            {
                // Initial state
                if (machine.CurrentStateId == machineNewStateId)
                {
                    // If there is at least one safety function related to some access point on this machine -> moving to next state "work in progress"
                    if (await dbContext.AccessPointSafetyFunctions.AnyAsync(apsf => machine.AccessPoints.Select(ap => ap.Id).Contains(apsf.AccessPointId)))
                        nextStateId = machineWorkInProgressStateId;
                }
                // Work in proress state
                else if (machine.CurrentStateId == machineWorkInProgressStateId)
                {
                    if (machine.TypeOfLogicId != 0 && machine.TypeOfLogicId is not null)
                        nextStateId = machineLogicSelectedStateId;
                }
                // Evaluted - valid + Evaluated - invalid states
                else if (machine.CurrentStateId == machineEvaluatedValidStateId || machine.CurrentStateId == machineEvaluatedInvalidStateId)
                {
                    // If number of access points changed than remove current type of logic a move machine to modified state
                    if (accessPointsCountChanged == true)
                    {
                        machine.TypeOfLogicId = null;
                        machine.TypeOfLogic = null;
                        nextStateId = machineModifiedStateId;
                    }
                }
                // Modified after evaluation state
                else if (machine.CurrentStateId == machineModifiedStateId)
                {
                    if (machine.TypeOfLogicId != 0 && machine.TypeOfLogicId is not null)
                        nextStateId = machineLogicSelectedStateId;
                }
            }
            if (machine.CurrentStateId == nextStateId)
                return;
            machine.CurrentStateId = nextStateId;
            dbContext.Update(machine);
            await dbContext.CommitChangesAsync(userId);
        }
    }
}
