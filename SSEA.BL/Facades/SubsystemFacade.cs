﻿using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.MainModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SubsystemFacade
    {
        private readonly IMapper mapper;
        private readonly SubsystemRepository subsystemRepository;
        private readonly SafetyFunctionFacade safetyFunctionFacade;
        private readonly IPerformanceLevelService performanceLevelService;

        public SubsystemFacade(IMapper mapper, SubsystemRepository subsystemRepository, SafetyFunctionFacade safetyFunctionFacade, IPerformanceLevelService performanceLevelService)
        {
            this.mapper = mapper;
            this.subsystemRepository = subsystemRepository;
            this.safetyFunctionFacade = safetyFunctionFacade;
            this.performanceLevelService = performanceLevelService;
        }

        public async Task<ICollection<SubsystemListModelPL>> GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)
        {
            var subsystems = await subsystemRepository.GetAllPLAsync(stateId, typeOfSubsystemId, operationPrincipleId, categoryId, performanceLevelId);
            return mapper.Map<ICollection<SubsystemListModelPL>>(subsystems);
        }

        public async Task<ICollection<SubsystemListModelSIL>> GetAllSILAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)
        {
            var subsystems = await subsystemRepository.GetAllSILAsync(stateId, typeOfSubsystemId, operationPrincipleId, architectureId, silId);
            return mapper.Map<ICollection<SubsystemListModelSIL>>(subsystems);
        }

        public async Task<SubsystemDetailModelPL> GetByIdPLAsync(int id)
        {
            SubsystemDetailModelPL subsystem = mapper.Map<SubsystemDetailModelPL>(await subsystemRepository.GetByIdPLAsync(id));
            subsystem.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(await subsystemRepository.GetCCFsForSubsystemAsync(id));
            return subsystem;
        }

        public async Task<SubsystemDetailModelSIL> GetByIdSILAsync(int id)
        {
            SubsystemDetailModelSIL subsystem = mapper.Map<SubsystemDetailModelSIL>(await subsystemRepository.GetByIdSILAsync(id));
            subsystem.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(await subsystemRepository.GetCCFsForSubsystemAsync(id));
            return subsystem;
        }

        public async Task<SubsystemCreationResponseModel> CreateAsync(SubsystemDetailModelPL subsystem, int userId, int safetyFunctionId)
        {
            try
            {
                await performanceLevelService.EvaluateSubsystemAsync(subsystem);
            }
            catch (Exception exception)
            {
                return new SubsystemCreationResponseModel()
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    SubsystemId = 0,
                };
            }
            Subsystem entity = mapper.Map<Subsystem>(subsystem);          
            int subsystemId = await subsystemRepository.CreateAsync(entity, userId, safetyFunctionId);
            if (subsystemId == 0)
            {
                return new SubsystemCreationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Saving of subsystem failed :(",
                    SubsystemId = subsystemId,
                };
            }

            // If subsystem has been saved successfully than also selected CCFs need to be saved
            await subsystemRepository.AddCCFsToSubsystemAsync(mapper.Map<ICollection<CCF>>(subsystem.SelectedCCFs), subsystemId);

            // If safetyFunctionId is not 0 than create record in join table
            if (safetyFunctionId != 0)
                await safetyFunctionFacade.AddSubsystemAsync(safetyFunctionId, subsystemId, userId);

            return new SubsystemCreationResponseModel()
            {
                IsSuccess = true,
                Message = "Subsystem created successfully :)",
                SubsystemId = subsystemId,
            };
        }

        public async Task<SubsystemCreationResponseModel> CreateAsync(SubsystemDetailModelSIL subsystem, int userId, int safetyFunctionId)
        {
            try
            {
                // TODO: evaluate subsystem
            }
            catch (Exception exception)
            {
                return new SubsystemCreationResponseModel()
                {
                    IsSuccess = false,
                    Message = exception.Message,
                    SubsystemId = 0,
                };
            }
            Subsystem entity = mapper.Map<Subsystem>(subsystem);
            int subsystemId = await subsystemRepository.CreateAsync(entity, userId, safetyFunctionId);
            if (subsystemId == 0)
            {
                return new SubsystemCreationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Saving of subsystem failed :(",
                    SubsystemId = subsystemId,
                };
            }

            // If subsystem has been saved successfully than also selected CCFs need to be saved
            await subsystemRepository.AddCCFsToSubsystemAsync(mapper.Map<ICollection<CCF>>(subsystem.SelectedCCFs), subsystemId);

            // If safetyFunctionId is not 0 than create record in join table
            if (safetyFunctionId != 0)
                await safetyFunctionFacade.AddSubsystemAsync(safetyFunctionId, subsystemId, userId);

            return new SubsystemCreationResponseModel()
            {
                IsSuccess = true,
                Message = "Subsystem created successfully :)",
                SubsystemId = subsystemId,
            };
        }

        public async Task DeleteAsync(int subsystemId, int userId)
        {
            await subsystemRepository.DeleteAsync(subsystemId, userId);
        }
    }
}
