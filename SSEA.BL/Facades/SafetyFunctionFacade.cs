using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL.Repositories;
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

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync()
        {
            var safetyFunctions = await safetyFunctionRepository.GetAllAsync();
            return mapper.Map<ICollection<SafetyFunctionListModel>>(safetyFunctions);
        }

        public async Task<SafetyFunctionDetailModelPL> GetByIdPLAsync(int id)
        {
            SafetyFunctionDetailModelPL safetyFunction = mapper.Map<SafetyFunctionDetailModelPL>(await safetyFunctionRepository.GetByIdPLAsync(id));
            var subsystems = mapper.Map<ICollection<SubsystemDetailModelPL>>(await safetyFunctionRepository.GetSubsystemsForSafetyFunctionPLAsync(id));

            // Selecting proper subsystems for navigation properties on SafetyFunctionDetailModelPL
            safetyFunction.InputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 1);
            safetyFunction.Communication1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
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
            safetyFunction.Communication1Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.LogicSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 3);
            safetyFunction.Communication2Subsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 4);
            safetyFunction.OutputSubsystem = subsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == 2);

            return safetyFunction;
        }



        //public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel, int userId)
        //{
        //    // newModel.SafetyFunctionSubsystems?.Clear();

        //    // Creating entity without collection
        //    var entity = mapper.Map<SafetyFunction>(newModel);

        //    // Assigning inital state to new record
        //    entity.CurrentState = await GetState(safetyFunctionNewStateId);

        //    // Assigning evaluation method
        //    entity.EvaluationMethod = await dbContext.EvaluationMethods.SingleOrDefaultAsync(e => e.Shortcut.Equals("PL"));

        //    dbContext.Attach(entity.TypeOfFunction).State = EntityState.Unchanged;
        //    dbContext.Attach(entity.EvaluationMethod).State = EntityState.Unchanged;
        //    if (entity.S != null && entity.F != null && entity.P != null)
        //    {
        //        dbContext.Attach(entity.S).State = EntityState.Unchanged;
        //        dbContext.Attach(entity.F).State = EntityState.Unchanged;
        //        dbContext.Attach(entity.P).State = EntityState.Unchanged;
        //        entity.PLr = await PLService.GetRequiredPLAsync(entity.S, entity.F, entity.P);
        //    }
        //    dbContext.Attach(entity.PLr).State = EntityState.Unchanged;

        //    await dbContext.SafetyFunctions.AddAsync(entity);
        //    await dbContext.CommitChangesAsync(userId);
        //    return entity.Id;
        //}

        //// TODO: incomplete implementation
        //public async Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel, int userId)
        //{
        //    newModel.SafetyFunctionSubsystems?.Clear();

        //    // Creating entity without collection
        //    var entity = mapper.Map<SafetyFunction>(newModel);

        //    // Assigning inital state to new record
        //    entity.CurrentState = await GetState(safetyFunctionNewStateId);

        //    dbContext.Attach(entity.TypeOfFunction).State = EntityState.Unchanged;
        //    dbContext.Attach(entity.EvaluationMethod).State = EntityState.Unchanged;
        //    if (entity.Se != null && entity.Fr != null && entity.Pr != null && entity.Av != null)
        //    {
        //        dbContext.Attach(entity.Se).State = EntityState.Unchanged;
        //        dbContext.Attach(entity.Fr).State = EntityState.Unchanged;
        //        dbContext.Attach(entity.Pr).State = EntityState.Unchanged;
        //        dbContext.Attach(entity.Av).State = EntityState.Unchanged;

        //        // TODO: get SILCL by calling SafetyIntegrityLevelService
        //    }
        //    dbContext.Attach(entity.SILCL).State = EntityState.Unchanged;

        //    await dbContext.SafetyFunctions.AddAsync(entity);
        //    await dbContext.CommitChangesAsync(userId);
        //    return entity.Id;
        //}

        //private async Task<State> GetState(int stateId)
        //{
        //    return await dbContext.States.SingleOrDefaultAsync(s => s.Id == stateId);
        //}
    }
}
