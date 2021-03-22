using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade
    {
        private readonly IMapper mapper;
        private readonly MachineRepository repository;

        public MachineFacade(IMapper mapper, MachineRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel, int userId)
        {
            Machine machineEntity = mapper.Map<Machine>(newModel);

            // Saving machine with AccessPoints
            int id = await repository.CreateAsync(machineEntity, userId);

            // Saving related norms
            ICollection<Norm> norms = mapper.Map<ICollection<Norm>>(newModel.Norms);
            await repository.AddNormsToMachine(norms, id);
        
            return id;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            var machines = await repository.GetAllAsync();
            return mapper.Map<ICollection<MachineListModel>>(machines);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = mapper.Map<MachineDetailModel>(await repository.GetByIdAsync(id));
            machine.Norms = mapper.Map<HashSet<NormModel>>(await repository.GetNormsForMachine(id));
            return machine;
        }


        //public async Task<int> DeleteAsync(int machineId, int userId)
        //{
        //    // Getting removed state for machines from DB with EntityState.Unchanged
        //    State removedState = await dbContext.States.SingleOrDefaultAsync(state => state.Id == machineRemovedStateId);

        //    var machineEntity = await GetMachineAsync(machineId);
        //    if (machineEntity == null)
        //        return 0;

        //    // Assigning state "removed" to existing machine and setting its state to modified
        //    machineEntity.CurrentState = removedState;
        //    dbContext.Entry(machineEntity).State = EntityState.Modified;

        //    await dbContext.CommitChangesAsync(userId);
        //    return machineEntity.Id;
        //}

        //public async Task<int> UpdateAsync(MachineDetailModel updatedModel, int userId)
        //{
        //    // TODO: do something with state of record

        //    var machineEntity = mapper.Map<Machine>(updatedModel);

        //    dbContext.Attach(machineEntity.EvaluationMethod).State = EntityState.Unchanged;
        //    dbContext.Attach(machineEntity.MachineType).State = EntityState.Unchanged;
        //    dbContext.Attach(machineEntity.Producer).State = EntityState.Unchanged;
        //    if (machineEntity.TypeOfLogic != null)
        //        dbContext.Attach(machineEntity.TypeOfLogic).State = EntityState.Unchanged;

        //    dbContext.Entry(machineEntity).State = EntityState.Modified;
        //    await dbContext.CommitChangesAsync(userId);
        //    return machineEntity.Id;
        //}

        // TODO: add GetAll method with filter
    }
}
