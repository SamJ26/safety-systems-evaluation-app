using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade : IFacade<MachineDetailModel, MachineListModel, Machine>
    {
        private readonly Repository<Machine> machineRepository;
        private readonly IMapper mapper;

        public MachineFacade(Repository<Machine> machineRepository,
                             IMapper mapper)
        {
            this.machineRepository = machineRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            // TODO: setup initial state for new machine
            return await machineRepository.InsertAsync(mapper.Map<Machine>(newModel));
        }

        public async Task DeleteAsync(int id)
        {
            var machine = await machineRepository.GetByIdAsync(id);
            // TODO: setup machine state to removed
            await machineRepository.UpdateAsync(machine);
        }

        public async Task<IEnumerable<MachineListModel>> GetAllAsync()
        {
            var data = await machineRepository.GetAll().Include(m => m.TypeOfLogic)
                                                       .ToListAsync();
            return mapper.Map<IEnumerable<MachineListModel>>(data);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = await machineRepository.GetByIdAsync(id);
            return mapper.Map<MachineDetailModel>(machine);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updatedModel)
        {
            // TODO: do some stuff with state of record
            return await machineRepository.UpdateAsync(mapper.Map<Machine>(updatedModel));
        }
    }
}
