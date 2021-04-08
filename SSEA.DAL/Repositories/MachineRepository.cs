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
        private readonly int accessPointNewStateId = 6;

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
            if (machine.TypeOfLogic != null)
                dbContext.Attach(machine.TypeOfLogic).State = EntityState.Unchanged;
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
    }
}
