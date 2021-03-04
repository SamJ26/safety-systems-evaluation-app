using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade : IFacade<MachineDetailModel, MachineListModel, Machine>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        private readonly int machineNewStateId = 1;
        private readonly int machineRemovedStateId = 4;

        public MachineFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // TODO: add GetAll method with filter

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            // Getting initial state for machines from DB with EntityState.Unchanged
            State initialState = await dbContext.States.SingleOrDefaultAsync(state => state.Id == machineNewStateId);

            Machine machineEntity = mapper.Map<Machine>(newModel);
            machineEntity.CurrentState = initialState;

            // Attaching existing related models to change tracker
            dbContext.Attach(machineEntity.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(machineEntity.MachineType).State = EntityState.Unchanged;
            dbContext.Attach(machineEntity.Producer).State = EntityState.Unchanged;

            await dbContext.Machines.AddAsync(machineEntity);
            await dbContext.SaveChangesAsync();
            return machineEntity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            // Getting removed state for machines from DB with EntityState.Unchanged
            State removedState = await dbContext.States.SingleOrDefaultAsync(state => state.Id == machineRemovedStateId);

            var machineEntity = await GetMachineAsync(id);
            if (machineEntity == null)
                return 0;

            // Assigning state "removed" to existing machine and setting its state to modified
            machineEntity.CurrentState = removedState;
            dbContext.Entry(machineEntity).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
            return machineEntity.Id;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            var machines = await dbContext.Machines.ToListAsync();
            return mapper.Map<ICollection<MachineListModel>>(machines);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machineEntity = await GetMachineAsync(id);
            return mapper.Map<MachineDetailModel>(machineEntity);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updatedModel)
        {
            // TODO: do something with state of record

            var machineEntity = mapper.Map<Machine>(updatedModel);

            dbContext.Attach(machineEntity.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(machineEntity.MachineType).State = EntityState.Unchanged;
            dbContext.Attach(machineEntity.Producer).State = EntityState.Unchanged;
            if (machineEntity.TypeOfLogic != null)
                dbContext.Attach(machineEntity.TypeOfLogic).State = EntityState.Unchanged;

            dbContext.Entry(machineEntity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return machineEntity.Id;
        }

        private async Task<Machine> GetMachineAsync(int id)
        {
            return await dbContext.Machines.Include(m => m.EvaluationMethod)
                                           .Include(m => m.MachineType)
                                           .Include(m => m.Producer)
                                           .Include(m => m.TypeOfLogic)
                                           .Include(m => m.AccessPoints)
                                           .Include(m => m.MachineNorms)
                                           .Include(m => m.CurrentState)
                                           .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
