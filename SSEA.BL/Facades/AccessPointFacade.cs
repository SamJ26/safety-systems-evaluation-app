using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly IMapper mapper;
        private readonly AccessPointRepository repository;

        public AccessPointFacade(IMapper mapper, AccessPointRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ICollection<AccessPointListModel>> GetAllAsync()
        {
            var data = await repository.GetAllAsync();
            return mapper.Map<ICollection<AccessPointListModel>>(data);
        }

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            AccessPointDetailModel accessPoint = mapper.Map<AccessPointDetailModel>(await repository.GetByIdAsync(id));
            accessPoint.SafetyFunctions = mapper.Map<ICollection<SafetyFunctionListModel>>(await repository.GetSafetyFunctionsForAccessPointAsync(accessPoint.Id));
            return accessPoint;
        }

        // TODO: add implementation
        public async Task<int> UpdateAsync(AccessPointDetailModel updatedModel, int userId)
        {
            // Getting unchanged access point model from database to compare with updated model
            AccessPointDetailModel oldModel = await GetByIdAsync(updatedModel.Id);

            #region Processing safety functions

            // Collection of newly created safety functions
            List<SafetyFunctionListModel> createdSafetyFunctions = new();

            // Collection of existing safety functions added to this access point
            List<SafetyFunctionListModel> addedSafetyFunctions = new();

            // After this foreach, oldModel.SafetyFunctions will contain safety functions which should be removed
            foreach (var safetyFunction in updatedModel.SafetyFunctions.ToList())
            {
                SafetyFunctionListModel foundSafetyFunction = oldModel.SafetyFunctions.FirstOrDefault(sf => sf.Id == safetyFunction.Id);

                // Item was not removed / added
                if (foundSafetyFunction is not null)
                    oldModel.SafetyFunctions.Remove(foundSafetyFunction);

                // Item was added to safety function and already exist in database
                if (foundSafetyFunction is null && safetyFunction.Id != 0)
                    addedSafetyFunctions.Add(safetyFunction);

                // Item was added to safety function and does not exist in database yet
                else if (foundSafetyFunction is null && safetyFunction.Id == 0)
                    createdSafetyFunctions.Add(safetyFunction);
            }

            // TODO: create new safety functions + join tables
            // TOOD: create join tables for existing safety functions

            #endregion

            AccessPoint accessPoint = mapper.Map<AccessPoint>(updatedModel);
            return await repository.UpdateAsync(accessPoint, userId);
        }

        // TODO: add implementation
        public async Task DeleteAsync(int accessPointId, int userId)
        {

        }
    }
}
