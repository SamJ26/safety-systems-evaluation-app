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
    public class SubsystemFacade : IExtendedFacade<SubsystemDetailModelPL, SubsystemDetialModelSIL, SubsystemListModel, Subsystem>
    {
        private readonly Repository<Machine> machineRepository;

        // TODO: inject IMapper
        public SubsystemFacade(Repository<Machine> machineRepository)
        {
            this.machineRepository = machineRepository;
        }

        public int Create(SubsystemDetailModelPL newModel)
        {
            throw new NotImplementedException();
        }

        public int Create(SubsystemDetialModelSIL newModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubsystemListModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubsystemDetailModelPL GetById()
        {
            throw new NotImplementedException();
        }

        public SubsystemDetialModelSIL GetById(int temp = 0)
        {
            throw new NotImplementedException();
        }

        public int Update(SubsystemDetailModelPL updatedModel)
        {
            throw new NotImplementedException();
        }

        public int Update(SubsystemDetialModelSIL updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
