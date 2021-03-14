using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly int accessPointRemovedStateId = 7;

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

        public async Task<int> DeleteAsync(int id, bool softDelelte = true)
        {
            var accessPoint = await GetAccessPointById(id);
            if (softDelelte)
            {
                // TODO: set up removed state to all records
            }
            else
            {
                dbContext.AccessPoints.Remove(accessPoint);
            }
            await dbContext.SaveChangesAsync();
            return accessPoint.Id;
        }

        public Task<ICollection<AccessPointListModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            AccessPoint data = await GetAccessPointById(id);
            return mapper.Map<AccessPointDetailModel>(data);
        }

        public async Task<int> UpdateAsync(AccessPointDetailModel updatedModel)
        {
            // Items which have set Id are already in database and so can be removed for upcoming processing
            foreach (var item in updatedModel.AccessPointSafetyFunctions)
            {
                // Item is already in database -> no operation with item
                if (item.Id != 0)
                    updatedModel.AccessPointSafetyFunctions.Remove(item);

                // Safety function is already in database -> creating new record in join table
                else if (item.SafetyFunctionId != 0)
                    item.SafetyFunction = null;

                // Safety function is new -> creating new safety function + record in join table
                else if (item.SafetyFunctionId == 0 && item.SafetyFunction != null)
                {
                    // Inserting new safety function to databse
                    var newSafetyFunction = mapper.Map<SafetyFunction>(item.SafetyFunction);
                    dbContext.SafetyFunctions.Add(newSafetyFunction);
                    await dbContext.SaveChangesAsync();

                    // Creating new record in join table in database
                    var newJoinTable = new AccessPointSafetyFunction()
                    {
                        AccessPointId = item.AccessPointId,
                        SafetyFunctionId = newSafetyFunction.Id,
                    };
                    dbContext.AccessPointSafetyFunctions.Add(newJoinTable);
                    await dbContext.SaveChangesAsync();

                    // When item is processed it can be removed from collection
                    updatedModel.AccessPointSafetyFunctions.Remove(item);
                }
            }

            // In collection remains just items with AccessPointId and SafetyFunctionId
            var entity = mapper.Map<AccessPoint>(updatedModel);
            dbContext.AccessPoints.Update(entity);
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        private async Task<AccessPoint> GetAccessPointById(int id)
        {
            return await dbContext.AccessPoints.Include(ap => ap.CurrentState)
                                               .Include(ap => ap.Machine)
                                                  .ThenInclude(m => m.EvaluationMethod)
                                               .Include(ap => ap.AccessPointSafetyFunctions)
                                                  .ThenInclude(apsf => apsf.SafetyFunction)
                                               .SingleOrDefaultAsync(ap => ap.Id == id);
        }
    }
}
