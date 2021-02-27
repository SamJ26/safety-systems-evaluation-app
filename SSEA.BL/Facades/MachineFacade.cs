using AutoMapper;
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

        public Task<int> CreateAsync(MachineDetailModel newModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MachineListModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MachineDetailModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MachineDetailModel updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
