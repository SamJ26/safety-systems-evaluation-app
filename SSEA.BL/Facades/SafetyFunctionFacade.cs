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
        private readonly SafetyFunctionRepository safetyFunctionRepository;
        private readonly IPerformanceLevelService PLService;

        public SafetyFunctionFacade(IMapper mapper, SafetyFunctionRepository safetyFunctionRepository, IPerformanceLevelService PLService)
        {
            this.mapper = mapper;
            this.safetyFunctionRepository = safetyFunctionRepository;
            this.PLService = PLService;
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(string name, int stateId, int typeOfFunctionId, int evaluationMethodId)
        {
            var safetyFunctions = await safetyFunctionRepository.GetAllAsync(name, stateId, typeOfFunctionId, evaluationMethodId);
            return mapper.Map<ICollection<SafetyFunctionListModel>>(safetyFunctions);
        }

        public async Task<SafetyFunctionDetailModelPL> GetByIdPLAsync(int id)
        {
            SafetyFunctionDetailModelPL safetyFunction = mapper.Map<SafetyFunctionDetailModelPL>(await safetyFunctionRepository.GetByIdPLAsync(id));
            var subsystems = mapper.Map<ICollection<SubsystemDetailModelPL>>(await safetyFunctionRepository.GetSubsystemsForSafetyFunctionPLAsync(id));

            // Selecting proper subsystems for navigation properties on SafetyFunctionDetailModelPL
            safetyFunction.InputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 1);
            var com1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.Communication1Subsystem = com1Subsystem;
            subsystems.Remove(com1Subsystem);
            safetyFunction.LogicSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 3);
            safetyFunction.Communication2Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.OutputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 2);

            return safetyFunction;
        }

        public async Task<SafetyFunctionDetailModelSIL> GetByIdSILAsync(int id)
        {
            SafetyFunctionDetailModelSIL safetyFunction = mapper.Map<SafetyFunctionDetailModelSIL>(await safetyFunctionRepository.GetByIdSILAsync(id));
            var subsystems = mapper.Map<ICollection<SubsystemDetailModelSIL>>(await safetyFunctionRepository.GetSubsystemsForSafetyFunctionSILAsync(id));

            // Selecting proper subsystems for navigation properties on SafetyFunctionDetailModelSIL
            safetyFunction.InputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 1);
            var com1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.Communication1Subsystem = com1Subsystem;
            subsystems.Remove(com1Subsystem);
            safetyFunction.LogicSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 3);
            safetyFunction.Communication2Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.OutputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 2);

            return safetyFunction;
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel, int userId)
        {
            // Evaluating required PL
            if (newModel.S is not null && newModel.F is not null && newModel.P is not null)
                newModel.PLr = await PLService.GetRequiredPLAsync(newModel.S, newModel.F, newModel.P);

            var entity = mapper.Map<SafetyFunction>(newModel);
            return await safetyFunctionRepository.CreateAsync(entity, userId);
        }

        // TODO: Create SF SIL

        public async Task<int> UpdateAsync(SafetyFunctionDetailModelPL updatedModel, int userId)
        {
            // Evaluating required PL
            if (updatedModel.S is not null && updatedModel.F is not null && updatedModel.P is not null)
                updatedModel.PLr = await PLService.GetRequiredPLAsync(updatedModel.S, updatedModel.F, updatedModel.P);

            SafetyFunction entity = mapper.Map<SafetyFunction>(updatedModel);
            return await safetyFunctionRepository.UpdateAsync(entity, userId);
        }

        // TODO: Update SF SIL

        // TODO: Delete SF

        public async Task AddSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            await safetyFunctionRepository.AddSubsystemAsync(safetyFunctionId, subsystemId);
        }

        public async Task RemoveSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            await safetyFunctionRepository.RemoveSubsystemAsync(safetyFunctionId, subsystemId);
        }

        public async Task<SafetyFunctionEvaluationResponseModel> EvaluateSafetyFunctionAsync(int safetyFunctionId, int userId)
        {
            SafetyFunctionDetailModelPL safetyFunction = mapper.Map<SafetyFunctionDetailModelPL>(await safetyFunctionRepository.GetByIdPLAsync(safetyFunctionId));
            try
            {
                await PLService.EvaluateSafetyFunctionAsync(safetyFunction);
            }
            catch (Exception exception)
            {
                return new SafetyFunctionEvaluationResponseModel()
                {
                    IsSuccess = false,
                    Message = exception.Message,
                };
            }

            // Updating record after its successful evaluation
            int id = await safetyFunctionRepository.UpdateAsync(mapper.Map<SafetyFunction>(safetyFunction), userId);
            if (id == 0)
            {
                return new SafetyFunctionEvaluationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Saving of evaluated safety function failed!",
                };
            }
            return new SafetyFunctionEvaluationResponseModel()
            {
                IsSuccess = true,
                Message = "Saving was successful :)",
            };
        }
    }
}
