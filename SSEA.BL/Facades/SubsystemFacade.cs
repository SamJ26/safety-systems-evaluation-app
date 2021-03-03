using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SubsystemFacade : IExtendedFacade<SubsystemDetailModelPL, SubsystemDetailModelSIL, SubsystemListModel, Subsystem>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public SubsystemFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Task<int> CreateAsync(SubsystemDetailModelPL newModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(SubsystemDetailModelSIL newModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SubsystemListModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubsystemDetailModelPL> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubsystemDetailModelSIL> GetByIdAsync(int id, int temp = 0)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SubsystemDetailModelPL updatedModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SubsystemDetailModelSIL updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
