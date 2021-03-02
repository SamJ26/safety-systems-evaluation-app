using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
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
    public class MachineFacade : IFacade<MachineDetailModel, MachineListModel, Machine>
    {
        private readonly Repository<Machine> machineRepository;
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly int machineTableId = 3;

        public MachineFacade(Repository<Machine> machineRepository,
                             AppDbContext dbContext,
                             IMapper mapper)
        {
            this.machineRepository = machineRepository;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            // Getting initial state for machines from DB with EntityState.Unchanged
            State initialState = await dbContext.States.SingleOrDefaultAsync(state => state.EntityId == machineTableId && state.InitialState == true);

            Machine machineEntity = mapper.Map<Machine>(newModel);
            machineEntity.CurrentState = initialState;

            // Attaching existing related models to change tracker
            dbContext.Attach(machineEntity.EvaluationMethod).State = EntityState.Unchanged;
            dbContext.Attach(machineEntity.MachineType).State = EntityState.Unchanged;
            //if (machineEntity.Producer != null)
            //    dbContext.Attach(machineEntity.Producer).State = EntityState.Unchanged;

            await dbContext.Machines.AddAsync(machineEntity);
            await dbContext.SaveChangesAsync();
            return machineEntity.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var machine = await GetByIdAsync(id);
            if (machine == null)
                return 0;
            // TODO: setup machine state to removed
            return await machineRepository.UpdateAsync(mapper.Map<Machine>(machine));
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            var data = await machineRepository.GetAll().Include(m => m.TypeOfLogic)
                                                       .ToListAsync();
            return mapper.Map<ICollection<MachineListModel>>(data);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = await machineRepository.GetAll().Include(m => m.EvaluationMethod)
                                                          .Include(m => m.MachineType)
                                                          .Include(m => m.Producer)
                                                          .Include(m => m.TypeOfLogic)
                                                          .Include(m => m.AccessPoints)
                                                          .Include(m => m.MachineNorms)
                                                          .SingleOrDefaultAsync(m => m.Id == id);
            return mapper.Map<MachineDetailModel>(machine);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updatedModel)
        {
            // TODO: do some stuff with state of record
            return await machineRepository.UpdateAsync(mapper.Map<Machine>(updatedModel));
        }
    }
}
