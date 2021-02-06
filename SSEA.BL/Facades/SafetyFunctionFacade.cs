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
    public class SafetyFunctionFacade : IExtendedFacade<SafetyFunctionDetailModelPL, SafetyFunctionDetailModelSIL, SafetyFunctionListModel, SafetyFunction>
    {
        private readonly AppDbContext dbContext;
        private readonly Repository<Machine> machineRepository;

        // TODO: inject IMapper
        public SafetyFunctionFacade(AppDbContext dbContext,
                                    Repository<Machine> machineRepository)
        {
            this.dbContext = dbContext;
            this.machineRepository = machineRepository;
        }

        public int Create(SafetyFunctionDetailModelPL newModel)
        {
            throw new NotImplementedException();
        }

        public int Create(SafetyFunctionDetailModelSIL newModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SafetyFunctionListModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SafetyFunctionDetailModelPL GetById()
        {
            throw new NotImplementedException();
        }

        public SafetyFunctionDetailModelSIL GetById(int temp = 0)
        {
            throw new NotImplementedException();
        }

        public int Update(SafetyFunctionDetailModelPL updatedModel)
        {
            throw new NotImplementedException();
        }

        public int Update(SafetyFunctionDetailModelSIL updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
