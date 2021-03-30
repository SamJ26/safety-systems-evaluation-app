using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.BL.Services.Interfaces;
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
    public class SubsystemFacade
    {
        private readonly IMapper mapper;
        private readonly SubsystemRepository subsystemRepository;
        private readonly IPerformanceLevelService PLService;

        public SubsystemFacade(IMapper mapper, SubsystemRepository subsystemRepository, IPerformanceLevelService PLService)
        {
            this.mapper = mapper;
            this.subsystemRepository = subsystemRepository;
            this.PLService = PLService;
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

        // TODO
        public async Task<int> CreateAsync(SubsystemDetailModelPL subsystem, int userId)
        {
            await PLService.EvaluateSubsystem(subsystem);
            bool valid = PLService.IsSubsystemValid(subsystem);

            // TODO: do some stuff according to valid var

            Subsystem entity = mapper.Map<Subsystem>(subsystem);
            return await subsystemRepository.CreateAsync(entity, userId);
        }
    }
}
