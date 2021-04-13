using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly IMapper mapper;
        private readonly AccessPointRepository accessPointRepository;
        private readonly MachineRepository machineRepository;

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

            // Deletion and creation of safety functions is managed by separate functions
            updatedModel.SafetyFunctions.Clear();

            // Updating access point
            AccessPoint accessPoint = mapper.Map<AccessPoint>(updatedModel);
            var id = await accessPointRepository.UpdateAsync(accessPoint, userId);

            return id;
        }

        public async Task DeleteAsync(int accessPointId, int userId)
        {
            await accessPointRepository.DeleteAsync(accessPointId, userId);
        }

        public async Task AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId, int userId)
        {
            await accessPointRepository.AddSafetyFunctionAsync(accessPointId, safetyFunctionId);

            // UPDATING STATE OF ACCESS POINT
            int machineId = await accessPointRepository.UpdateAccessPointStateAsync(accessPointId, userId);

            // UPDATING STATE OF MACHINE
            await machineRepository.UpdateMachineStateAsync(machineId, userId);
        }

        public async Task RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId, int userId)
        {
            await accessPointRepository.RemoveSafetyFunctionAsync(accessPointId, safetyFunctionId);

            // UPDATING STATE OF ACCESS POINT
            int machineId = await accessPointRepository.UpdateAccessPointStateAsync(accessPointId, userId);

            // UPDATING STATE OF MACHINE
            await machineRepository.UpdateMachineStateAsync(machineId, userId);
        }
    }
}
