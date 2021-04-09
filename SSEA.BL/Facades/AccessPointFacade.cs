using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly IMapper mapper;
        private readonly AccessPointRepository accessPointRepository;
        private readonly MachineRepository machineRepository;

        private readonly int machineWorkInProgressStateId = 2;
        private readonly int accessPointWorkInProgressStateId = 7;

        public AccessPointFacade(IMapper mapper, AccessPointRepository accessPointRepository, MachineRepository machineRepository)
        {
            this.mapper = mapper;
            this.accessPointRepository = accessPointRepository;
            this.machineRepository = machineRepository;
        }

        public async Task<ICollection<AccessPointListModel>> GetAllAsync()
        {
            var data = await accessPointRepository.GetAllAsync();
            return mapper.Map<ICollection<AccessPointListModel>>(data);
        }

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            AccessPointDetailModel accessPoint = mapper.Map<AccessPointDetailModel>(await accessPointRepository.GetByIdAsync(id));
            accessPoint.SafetyFunctions = mapper.Map<ICollection<SafetyFunctionListModel>>(await accessPointRepository.GetSafetyFunctionsForAccessPointAsync(accessPoint.Id));
            return accessPoint;
        }

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

            // Collection of join entities which should be inserted to database
            List<AccessPointSafetyFunction> joinEntites = new();

            // Preparing join entites between updated access point and existing safety functions
            foreach (var safetyFunction in addedSafetyFunctions)
            {
                joinEntites.Add(new AccessPointSafetyFunction()
                {
                    AccessPointId = updatedModel.Id,
                    SafetyFunctionId = safetyFunction.Id,
                });
            }

            // Inserting new records to AccessPointSafetyFunction join table
            if (joinEntites.Count != 0)
                await accessPointRepository.AddExistingSafetyFunctionsAsync(joinEntites);

            // Inserting newly created safety functions + created entites in join table
            if (createdSafetyFunctions.Count != 0)
                await accessPointRepository.AddNewSafetyFunctionsAsync(mapper.Map<ICollection<SafetyFunction>>(createdSafetyFunctions), updatedModel.Id, userId);

            // Removing records from AccessPointSafetyFunction join table
            if (oldModel.SafetyFunctions.Count != 0)
                await accessPointRepository.RemoveSafetyFunctionsAsync(mapper.Map<ICollection<SafetyFunction>>(oldModel.SafetyFunctions), updatedModel.Id);

            // Safety functions are processed -> collection can be cleared
            updatedModel.SafetyFunctions.Clear();

            #endregion

            // Updating access point
            AccessPoint accessPoint = mapper.Map<AccessPoint>(updatedModel);

            // --- STATE CHANGE --- updating state of machine and access point to work in progress after adding at least one safety function
            if (joinEntites.Count != 0 || createdSafetyFunctions.Count != 0)
            {
                await machineRepository.UpdateMachineStateAsync(accessPoint.MachineId, machineWorkInProgressStateId, userId);
                accessPoint.CurrentStateId = accessPointWorkInProgressStateId;
            }

            return await accessPointRepository.UpdateAsync(accessPoint, userId);
        }

        public async Task DeleteAsync(int accessPointId, int userId)
        {
            await accessPointRepository.DeleteAsync(accessPointId, userId);
        }
    }
}
