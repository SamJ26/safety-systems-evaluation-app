using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SafetyFunctionFacade
    {
        private readonly IMapper mapper;
        private readonly AccessPointFacade accessPointFacade;
        private readonly UserRepository userRepository;
        private readonly SubsystemRepository subsystemRepository;
        private readonly SafetyFunctionRepository safetyFunctionRepository;
        private readonly IPerformanceLevelService performanceLevelService;
        private readonly ISafetyIntegrityLevelService safetyIntegrityLevelService;

        public SafetyFunctionFacade(IMapper mapper,
                                    AccessPointFacade accessPointFacade,
                                    UserRepository userRepository,
                                    SubsystemRepository subsystemRepository,
                                    SafetyFunctionRepository safetyFunctionRepository,
                                    IPerformanceLevelService performanceLevelService,
                                    ISafetyIntegrityLevelService safetyIntegrityLevelService)
        {
            this.mapper = mapper;
            this.accessPointFacade = accessPointFacade;
            this.userRepository = userRepository;
            this.subsystemRepository = subsystemRepository;
            this.safetyFunctionRepository = safetyFunctionRepository;
            this.performanceLevelService = performanceLevelService;
            this.safetyIntegrityLevelService = safetyIntegrityLevelService;
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(string name, int stateId, int typeOfFunctionId, int evaluationMethodId)
        {
            var safetyFunctions = await safetyFunctionRepository.GetAllAsync(name, stateId, typeOfFunctionId, evaluationMethodId);
            return mapper.Map<ICollection<SafetyFunctionListModel>>(safetyFunctions);
        }

        public async Task<SafetyFunctionDetailModelPL> GetByIdPLAsync(int id)
        {
            SafetyFunctionDetailModelPL safetyFunction = mapper.Map<SafetyFunctionDetailModelPL>(await safetyFunctionRepository.GetByIdPLAsync(id));
            safetyFunction.UserNameCreated = await userRepository.GetUserNameById(safetyFunction.IdCreated);
            safetyFunction.UserNameUpdated = safetyFunction.IdCreated == safetyFunction.IdUpdated ? safetyFunction.UserNameCreated : await userRepository.GetUserNameById(safetyFunction.IdUpdated);
            
            var subsystems = mapper.Map<ICollection<SubsystemDetailModelPL>>(await safetyFunctionRepository.GetSubsystemsForSafetyFunctionPLAsync(id));

            // Selecting proper subsystems for navigation properties on SafetyFunctionDetailModelPL
            safetyFunction.InputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 1);
            safetyFunction.Communication1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.LogicSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 3);
            safetyFunction.Communication2Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 5);
            safetyFunction.OutputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 2);

            return safetyFunction;
        }

        public async Task<SafetyFunctionDetailModelSIL> GetByIdSILAsync(int id)
        {
            SafetyFunctionDetailModelSIL safetyFunction = mapper.Map<SafetyFunctionDetailModelSIL>(await safetyFunctionRepository.GetByIdSILAsync(id));
            safetyFunction.UserNameCreated = await userRepository.GetUserNameById(safetyFunction.IdCreated);
            safetyFunction.UserNameUpdated = safetyFunction.IdCreated == safetyFunction.IdUpdated ? safetyFunction.UserNameCreated : await userRepository.GetUserNameById(safetyFunction.IdUpdated);
            
            var subsystems = mapper.Map<ICollection<SubsystemDetailModelSIL>>(await safetyFunctionRepository.GetSubsystemsForSafetyFunctionSILAsync(id));

            // Selecting proper subsystems for navigation properties on SafetyFunctionDetailModelPL
            safetyFunction.InputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 1);
            safetyFunction.Communication1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.LogicSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 3);
            safetyFunction.Communication2Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 5);
            safetyFunction.OutputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 2);

            return safetyFunction;
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel, int userId, int accessPointId)
        {
            // Evaluating required PL
            if (newModel.S is not null && newModel.F is not null && newModel.P is not null)
                newModel.RequiredPL = await performanceLevelService.GetRequiredPLAsync(newModel.S, newModel.F, newModel.P);

            if (newModel.RequiredPL is null)
                return 0;

            newModel.UsedOnMachine = accessPointId != 0;
            var entity = mapper.Map<SafetyFunction>(newModel);
            int safetyFunctionId = await safetyFunctionRepository.CreateAsync(entity, userId);

            // If safety function was saved successfully and accessPointId is not zero than we have to create new record in AccessPointSafetyFunction join table
            if (safetyFunctionId != 0 && accessPointId != 0)
                await accessPointFacade.AddSafetyFunctionAsync(accessPointId, safetyFunctionId, userId);

            return safetyFunctionId;
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel, int userId, int accessPointId)
        {
            // Evaluation of required SIL
            if (newModel.Se is not null && newModel.Fr is not null && newModel.Pr is not null && newModel.Av is not null)
                newModel.RequiredSIL = await safetyIntegrityLevelService.GetRequiredSILAsync(newModel.Se, newModel.Fr, newModel.Pr, newModel.Av);

            if (newModel.RequiredSIL is null)
                return 0;

            newModel.UsedOnMachine = accessPointId != 0;
            var entity = mapper.Map<SafetyFunction>(newModel);
            int safetyFunctionId = await safetyFunctionRepository.CreateAsync(entity, userId);

            // If safety function was saved successfully and accessPointId is not zero than we have to create new record in AccessPointSafetyFunction join table
            if (safetyFunctionId != 0 && accessPointId != 0)
                await accessPointFacade.AddSafetyFunctionAsync(accessPointId, safetyFunctionId, userId);

            return safetyFunctionId;
        }

        public async Task<int> UpdateAsync<T>(T updatedModel, int userId)
        {
            SafetyFunction entity = mapper.Map<SafetyFunction>(updatedModel);
            return await safetyFunctionRepository.UpdateAsync(entity, userId);
        }

        public async Task DeleteAsync(int safetyFunctionId, int userId)
        {
            await safetyFunctionRepository.DeleteAsync(safetyFunctionId, userId);
        }


        // TODO: refactor
        public async Task AddSubsystemAsync(int safetyFunctionId, int subsystemId, int userId)
        {
            await safetyFunctionRepository.AddSubsystemAsync(safetyFunctionId, subsystemId);

            // UPDATING STATE OF SAFETY FUNCTION
            await safetyFunctionRepository.UpdateSafetyFunctionStateAsync(safetyFunctionId, userId);

            // UPDATING STATE OF SUBSYSTEM
            await subsystemRepository.UpdateSubsystemStateAsync(subsystemId, userId);
        }

        // TODO: refactor
        public async Task RemoveSubsystemAsync(int safetyFunctionId, int subsystemId, int userId)
        {
            await safetyFunctionRepository.RemoveSubsystemAsync(safetyFunctionId, subsystemId);

            // UPDATING STATE OF SAFETY FUNCTION
            await safetyFunctionRepository.UpdateSafetyFunctionStateAsync(safetyFunctionId, userId);

            // UPDATING STATE OF SUBSYSTEM
            await subsystemRepository.UpdateSubsystemStateAsync(subsystemId, userId);
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyFunctionPLAsync(int safetyFunctionId, int userId)
        {
            return await EvaluateSafetyFunctionAsync(GetByIdPLAsync, performanceLevelService.EvaluateSafetyFunctionAsync, safetyFunctionId, userId);
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyFunctionSILAsync(int safetyFunctionId, int userId)
        {
            return await EvaluateSafetyFunctionAsync(GetByIdSILAsync, safetyIntegrityLevelService.EvaluateSafetyFunctionAsync, safetyFunctionId, userId);
        }

        private async Task<SafetyEvaluationResponseModel> EvaluateSafetyFunctionAsync<T>(Func<int, Task<T>> getByIdFunc, Func<T, Task<bool>> evaluateSafetyFunc, int safetyFunctionId, int userId)
        {
            T safetyFunction = await getByIdFunc(safetyFunctionId);
            bool evaluationResult;
            try
            {
                evaluationResult = await evaluateSafetyFunc(safetyFunction);
            }
            catch (Exception exception)
            {
                return new SafetyEvaluationResponseModel()
                {
                    IsSuccess = false,
                    Message = exception.Message,
                };
            }

            // Resultant level of safety is not valid
            if (evaluationResult == false)
                return new SafetyEvaluationResponseModel()
                {
                    IsSuccess = false,
                    IsValidSafetyLevel = false,
                    Message = $"Calculated level of safety is lower than required level - change subsystems of safety function and try it again :(",
                };

            // Resultant level of safety is valid
            int id = await safetyFunctionRepository.UpdateAsync(mapper.Map<SafetyFunction>(safetyFunction), userId);
            if (id == 0)
            {
                return new SafetyEvaluationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Saving of evaluated safety function failed!",
                };
            }

            int safetyFunctionValidStateId = 14;
            await safetyFunctionRepository.UpdateSafetyFunctionStateAsync(id, userId, safetyFunctionValidStateId);

            return new SafetyEvaluationResponseModel()
            {
                IsSuccess = true,
                IsValidSafetyLevel = true,
                Message = $"Calculated value of safety is valid - safety function is locked for further modifications :)",
            };
        }
    }
}
