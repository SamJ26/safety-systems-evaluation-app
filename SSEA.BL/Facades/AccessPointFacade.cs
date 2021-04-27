using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SSEA.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly IMapper mapper;
        private readonly UserRepository userRepository;
        private readonly MachineRepository machineRepository;
        private readonly AccessPointRepository accessPointRepository;
        private readonly SafetyFunctionRepository safetyFunctionRepository;

        public AccessPointFacade(IMapper mapper,
                                 UserRepository userRepository,
                                 MachineRepository machineRepository,
                                 AccessPointRepository accessPointRepository,
                                 SafetyFunctionRepository safetyFunctionRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.machineRepository = machineRepository;
            this.accessPointRepository = accessPointRepository;
            this.safetyFunctionRepository = safetyFunctionRepository;
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
            accessPoint.UserNameCreated = await userRepository.GetUserNameById(accessPoint.IdCreated);
            accessPoint.UserNameUpdated = accessPoint.IdCreated == accessPoint.IdUpdated ? accessPoint.UserNameCreated : await userRepository.GetUserNameById(accessPoint.IdUpdated);
            return accessPoint;
        }

        public async Task<int> UpdateAsync(AccessPointDetailModel updatedModel, int userId)
        {
            if (await userRepository.IsAuthorized<AccessPoint>(userId, updatedModel.Id) == false)
                throw new UnauthorizedAccessException();
            AccessPoint accessPoint = mapper.Map<AccessPoint>(updatedModel);
            return await accessPointRepository.UpdateAsync(accessPoint, userId);
        }

        public async Task DeleteAsync(int accessPointId, int userId)
        {
            if (await userRepository.IsAuthorized<AccessPoint>(userId, accessPointId) == false)
                throw new UnauthorizedAccessException();
            await accessPointRepository.DeleteAsync(accessPointId, userId);
        }

        public async Task AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId, int userId)
        {
            if (await userRepository.IsAuthorized<AccessPoint>(userId, accessPointId) == false)
                throw new UnauthorizedAccessException();
            await ManageSafetyFunctionsAsync(accessPointRepository.AddSafetyFunctionAsync, accessPointId, safetyFunctionId, userId);
        }

        public async Task RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId, int userId)
        {
            if (await userRepository.IsAuthorized<AccessPoint>(userId, accessPointId) == false)
                throw new UnauthorizedAccessException();
            await ManageSafetyFunctionsAsync(accessPointRepository.RemoveSafetyFunctionAsync, accessPointId, safetyFunctionId, userId);
        }

        private async Task ManageSafetyFunctionsAsync(Func<int, int, Task> operation, int accessPointId, int safetyFunctionId, int userId)
        {
            await operation(accessPointId, safetyFunctionId);

            // UPDATING STATE OF ACCESS POINT
            int machineId = await accessPointRepository.UpdateAccessPointStateAsync(accessPointId, userId);

            // UPDATING STATE OF MACHINE
            await machineRepository.UpdateMachineStateAsync(machineId, userId, accessPointsCountChanged: true);

            // UPDATING STATE OF SAFETY FUNCTION
            await safetyFunctionRepository.UpdateSafetyFunctionStateAsync(safetyFunctionId, userId);
        }
    }
}
