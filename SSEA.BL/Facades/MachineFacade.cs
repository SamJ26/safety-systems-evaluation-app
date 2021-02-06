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
    public class MachineFacade : IFacade<MachineDM, MachineLM, Machine>
    {
        private readonly AppDbContext dbContext;
        private readonly Repository<Machine> machineRepository;

        // TODO: inject IMapper
        public MachineFacade(AppDbContext dbContext,
                             Repository<Machine> machineRepository)
        {
            this.dbContext = dbContext;
            this.machineRepository = machineRepository;
        }

        public int Create(MachineDM newModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MachineLM> GetAll()
        {
            throw new NotImplementedException();
        }

        public MachineDM GetById()
        {
            throw new NotImplementedException();
        }

        public int Update(MachineDM updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
