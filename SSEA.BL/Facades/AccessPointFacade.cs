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
    public class AccessPointFacade : IFacade<AccessPointDetailModel, AccessPointListModel, AccessPoint>
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public AccessPointFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // TODO: add GetAll method with filter

        public Task<int> CreateAsync(AccessPointDetailModel newModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AccessPointListModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AccessPointDetailModel updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
