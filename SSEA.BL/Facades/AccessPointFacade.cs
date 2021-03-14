using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            AccessPoint data = await dbContext.AccessPoints.Include(ap => ap.CurrentState)
                                                           .Include(ap => ap.Machine)
                                                              .ThenInclude(m => m.EvaluationMethod)
                                                           .Include(ap => ap.AccessPointSafetyFunctions)
                                                              .ThenInclude(apsf => apsf.SafetyFunction)
                                                           .SingleOrDefaultAsync(ap => ap.Id == id);
            return mapper.Map<AccessPointDetailModel>(data);
        }

        public Task<int> UpdateAsync(AccessPointDetailModel updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
