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
