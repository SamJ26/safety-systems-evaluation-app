using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.BL.Facades
{
    public class MachineFacade : IFacade<MachineDetailModel, MachineListModel, Machine>
    {
        private readonly Repository<Machine> machineRepository;

        // TODO: inject IMapper
        public MachineFacade(Repository<Machine> machineRepository)
        {
            this.machineRepository = machineRepository;
        }

        public int Create(MachineDetailModel newModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MachineListModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public MachineDetailModel GetById()
        {
            throw new NotImplementedException();
        }

        public int Update(MachineDetailModel updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
