using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.MainModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade
    {
        private readonly IMapper mapper;
        private readonly UserRepository userRepository;
        private readonly MachineRepository machineRepository;
        private readonly AccessPointRepository accessPointRepository;
        private readonly SafetyFunctionRepository safetyFunctionRepository;
        private readonly CodeListFacade codeListFacade;
        private readonly SafetyFunctionFacade safetyFunctionFacade;

        public MachineFacade(IMapper mapper,
                             UserRepository userRepository,
                             MachineRepository machineRepository,
                             AccessPointRepository accessPointRepository,
                             SafetyFunctionRepository safetyFunctionRepository,
                             CodeListFacade codeListFacade,
                             SafetyFunctionFacade safetyFunctionFacade)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.machineRepository = machineRepository;
            this.accessPointRepository = accessPointRepository;
            this.safetyFunctionRepository = safetyFunctionRepository;
            this.codeListFacade = codeListFacade;
            this.safetyFunctionFacade = safetyFunctionFacade;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel, int userId)
        {
            Machine machineEntity = mapper.Map<Machine>(newModel);

            // Saving machine with AccessPoints
            int id = await machineRepository.CreateAsync(machineEntity, userId);

            // Saving related norms
            ICollection<Norm> norms = mapper.Map<ICollection<Norm>>(newModel.Norms);
            await machineRepository.AddNormsToMachineAsync(norms, id);
        
            return id;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync(string machineName, int stateId, int machineTypeId, int evaluationMethodId, int producerId)
        {
            var machines = await machineRepository.GetAllAsync(machineName, stateId, machineTypeId, evaluationMethodId, producerId);
            return mapper.Map<ICollection<MachineListModel>>(machines);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = mapper.Map<MachineDetailModel>(await machineRepository.GetByIdAsync(id));
            if (machine is null)
                return null;

            foreach (var accessPoint in machine.AccessPoints)
                accessPoint.SafetyFunctionsCount = await accessPointRepository.GetSafetyFunctionsCountAsync(accessPoint.Id);

            machine.Norms = mapper.Map<HashSet<NormModel>>(await machineRepository.GetNormsForMachineAsync(id));
            machine.UserNameCreated = await userRepository.GetUserNameById(machine.IdCreated);
            machine.UserNameUpdated = machine.IdCreated == machine.IdUpdated ? machine.UserNameCreated : await userRepository.GetUserNameById(machine.IdUpdated);
            return machine;
        }

        public async Task<int> UpdateAsync(MachineDetailModel updatedModel, int userId)
        {
            // Getting unchanged machine from database to compare with updated model
            MachineDetailModel oldModel = await GetByIdAsync(updatedModel.Id);

            #region Processing norms

            ICollection<NormModel> addedNorms = new List<NormModel>();

            // After this foreach, oldModel.Norms will contain norms which should be removed
            foreach (var norm in updatedModel.Norms.ToList())
            {
                NormModel foundNorm = oldModel.Norms.FirstOrDefault(n => n.Id == norm.Id);

                // Item was not removed / added
                if (foundNorm is not null)
                    oldModel.Norms.Remove(foundNorm);

                // Item was added
                else if (foundNorm is null)
                    addedNorms.Add(norm);
            }

            // Removing norms
            foreach (var norm in oldModel.Norms)
                await machineRepository.RemoveNormAsync(updatedModel.Id, norm.Id);

            // Adding new norms to machine
            if (addedNorms.Count != 0)
                await machineRepository.AddNormsToMachineAsync(mapper.Map<ICollection<Norm>>(addedNorms), updatedModel.Id);

            // Norms are processed -> can be cleared
            updatedModel.Norms.Clear();

            #endregion

            #region Processing access points

            // After this foreach, oldModel.AccessPoints will contain access points which should be removed
            bool accessPointsChanged = false;
            foreach (var accessPoint in updatedModel.AccessPoints.ToList())
            {
                AccessPointListModel foundAccessPoint = oldModel.AccessPoints.FirstOrDefault(ap => ap.Id == accessPoint.Id);

                // Item is in both collections -> was not removed / added
                if (foundAccessPoint is not null)
                    oldModel.AccessPoints.Remove(foundAccessPoint);
                // Item was added or removed
                else
                    accessPointsChanged = true;
            }

            // Removing access points
            foreach (var accessPoint in oldModel.AccessPoints)
            {
                await accessPointRepository.DeleteAsync(accessPoint.Id, userId);
            }

            #endregion

            // Creating machine entity with machine properties and access point collection
            Machine machineEntity = mapper.Map<Machine>(updatedModel);

            var id = await machineRepository.UpdateAsync(machineEntity, userId);

            // UPDATING STATE OF MACHINE
            await machineRepository.UpdateMachineStateAsync(id, userId, accessPointsCountChanged: accessPointsChanged);

            return id;
        }

        public async Task DeleteAsync(int machineId, int userId)
        {
            await machineRepository.DeleteAsync(machineId, userId);
        }

        public async Task<MachineLogicSelectionResponseModel> SelectLogicAsync(int machineId)
        {
            int inputSubsystemId = 1;
            int outputSubsystemId = 2;
            int inputLogicSubsystemId = 4;
            int outputLogicSubsystemId = 5;

            int safetyFunctionReadyForEvaluationStateNumber = 3;
            int accessPointWorkInProgressStateNumber = 2;

            // Getting machine with all its access points
            MachineDetailModel machine = await GetByIdAsync(machineId);

            if (machine is null)
                return null;

            if (machine.AccessPoints is null || machine.AccessPoints?.Count == 0)
                return new MachineLogicSelectionResponseModel()
                {
                    IsSuccess = false,
                    Message = "The machine has no access points",
                };

            HashSet<Subsystem> subsystems = new();

            uint accessPointsWithoutSafetyFunction = 0;
            bool machineWithoutSafetyFunction = true;

            // Searching cycle for getting all input-logic and output-logic subsystems
            foreach (var accessPoint in machine.AccessPoints)
            {
                // Checking if current access point has at least one safety function
                if (accessPoint.CurrentState.StateNumber < accessPointWorkInProgressStateNumber)
                {
                    ++accessPointsWithoutSafetyFunction;
                    continue;
                }

                // Getting all safety functions for current access point
                var safetyFunctions = mapper.Map<ICollection<SafetyFunctionListModel>>(await accessPointRepository.GetSafetyFunctionsForAccessPointAsync(accessPoint.Id));

                foreach (var safetyFunction in safetyFunctions)
                {
                    machineWithoutSafetyFunction = false;

                    if (safetyFunction.CurrentState.StateNumber < safetyFunctionReadyForEvaluationStateNumber)
                        return new MachineLogicSelectionResponseModel()
                        {
                            IsSuccess = false,
                            Message = $"Safety function with name {safetyFunction.Name} is not ready for evaluation - input or output subsystem is missing",
                        };

                    // Getting all subsystems used for given safety function
                    var usedSubsystems = await safetyFunctionRepository.GetSubsystemsForSafetyFunctionAsync(safetyFunction.Id);

                    // If safety function has input-logic subsystem than use this one instead of input subsystem for further processing
                    var inputLogicSubsystem = usedSubsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == inputLogicSubsystemId);
                    if (inputLogicSubsystem is not null)
                        subsystems.Add(inputLogicSubsystem);
                    else
                        subsystems.Add(usedSubsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == inputSubsystemId));

                    // If safety function has output-logic subsystem than use this one instead of output subsystem for further processing
                    var outputLogicSubsystem = usedSubsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == outputLogicSubsystemId);
                    if (outputLogicSubsystem is not null)
                        subsystems.Add(outputLogicSubsystem);
                    else
                        subsystems.Add(usedSubsystems.FirstOrDefault(s => s.TypeOfSubsystem.Id == outputSubsystemId));
                }
            }

            if (accessPointsWithoutSafetyFunction == machine.AccessPoints.Count || machineWithoutSafetyFunction)
                return new MachineLogicSelectionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Machine has zero safety functions",
                };

            uint inputs = 0;
            uint outputs = 0;

            // At this point we are ready to iterate found subsystems and count their elements
            foreach (var subsystem in subsystems)
            {
                if (subsystem.TypeOfSubsystem.Id == inputLogicSubsystemId || subsystem.TypeOfSubsystem.Id == inputSubsystemId)
                    inputs += (uint)(subsystem.Category is not null ? subsystem.Category.Channels : subsystem.Architecture.Channels);
                if (subsystem.TypeOfSubsystem.Id == outputLogicSubsystemId || subsystem.TypeOfSubsystem.Id == outputSubsystemId)
                    outputs += (uint)(subsystem.Category is not null ? subsystem.Category.Channels : subsystem.Architecture.Channels);
            }

            if (inputs == 0 || outputs == 0)
                return new MachineLogicSelectionResponseModel()
                {
                    IsSuccess = false,
                    Message = "Number of standard inputs or outputs is zero"
                };

            // Selecting proper logic for given machine according to number of SI and SO
            TypeOfLogicModel logic = await SelectLogicAsync(inputs, outputs);

            if (logic is null)
                return new MachineLogicSelectionResponseModel()
                {
                    IsSuccess = false,
                    Message = "No type of logics available - report this issue to administrator",
                };

            return new MachineLogicSelectionResponseModel()
            {
                IsSuccess = true,
                Message = "Logic selected successfully",
                Logic = logic,
            };
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyAsync(int machineId, int userId)
        {
            int accessPointProtectedStateId = 9;
            int accessPointNotProtectedStateId = 10;
            int machineEvaluatedValidStateId = 4;
            int machineEvaluatedInvalidStateId = 5;

            // Getting machine with all its access points
            MachineDetailModel machine = await GetByIdAsync(machineId);
            if (machine is null)
                return null;

            // Choosing right function for evaluation according to methodics which is used for machine
            Func<int, int, Task<SafetyEvaluationResponseModel>> evaluateSafety;
            if (machine.EvaluationMethod.Shortcut.Equals("PL"))
                evaluateSafety = safetyFunctionFacade.EvaluateSafetyFunctionPLAsync;
            else
                evaluateSafety = safetyFunctionFacade.EvaluateSafetyFunctionSILAsync;

            // Check if machine has selected logic
            if (machine.CurrentState.StateNumber < 3 || machine.TypeOfLogic is null)
                return new SafetyEvaluationResponseModel()
                {
                    IsSuccess = false,
                    Message = "Logic is not selected",
                };

            bool machineWithInvalidSafetyFunction = false;

            // Iterating over all acess points of machine
            foreach (var accessPoint in machine.AccessPoints)
            {
                bool accessPointProtected = false;

                // Getting all safety functions for current access point
                var safetyFunctions = mapper.Map<ICollection<SafetyFunctionListModel>>(await accessPointRepository.GetSafetyFunctionsForAccessPointAsync(accessPoint.Id));

                // Iterating over all safety functions of access point
                foreach (var safetyFunction in safetyFunctions)
                {
                    // If safety function is already evaluated than continue to next one
                    if (safetyFunction.CurrentState.StateNumber >= 4)
                    {
                        if (safetyFunction.CurrentState.StateNumber == 4)
                            accessPointProtected = true;
                        continue;
                    }

                    bool hasLogic = await safetyFunctionRepository.SafetyFunctionHasLogicAsync(safetyFunction.Id);
                    SafetyEvaluationResponseModel evaluationResult;

                    // If safety function has not logical subsystem than add selected logic as logical subsystem
                    if (hasLogic == false)
                        await safetyFunctionFacade.AddSubsystemAsync(safetyFunction.Id, machine.TypeOfLogic.SubsystemId, userId);

                    evaluationResult = await evaluateSafety(safetyFunction.Id, userId);

                    if (evaluationResult.IsValidSafetyLevel)
                        accessPointProtected = true;
                    else
                        machineWithInvalidSafetyFunction = true;
                }

                // UPDATING STATE OF ACCESS POINT
                await accessPointRepository.UpdateAccessPointStateAsync(accessPoint.Id, userId, accessPointProtected == true ? accessPointProtectedStateId : accessPointNotProtectedStateId);
            }

            // UPDATING STATE OF MACHINE
            await machineRepository.UpdateMachineStateAsync(machineId, userId, machineWithInvalidSafetyFunction == true ? machineEvaluatedInvalidStateId : machineEvaluatedValidStateId);

            return new SafetyEvaluationResponseModel()
            {
                IsSuccess = true,
                Message = "Evaluation was successfull",
            };
        }

        public async Task<MachineSafetySummaryModel> GetSafetyEvaluationSummary(int machineId)
        {
            // Getting machine with all its access points
            MachineDetailModel machine = await GetByIdAsync(machineId);
            if (machine is null)
                return null;

            MachineSafetySummaryModel model = new()
            {
                MachineId = machine.Id,
                MachineName = machine.Name,
                MachineState = machine.CurrentState,
                AccessPoints = new List<AccessPointInfo>(),
            };

            // Iterating over all acess points of machine
            foreach (var accessPoint in machine.AccessPoints)
            {
                AccessPointInfo accessPointInfo = new()
                {
                    AccessPointId = accessPoint.Id,
                    AccessPointName = accessPoint.Name,
                    AccessPointState = accessPoint.CurrentState,
                    SafetyFunctions = new List<SafetyFunctionInfo>(),
                };

                // Getting all safety functions for current access point
                var safetyFunctions = mapper.Map<ICollection<SafetyFunctionListModel>>(await accessPointRepository.GetSafetyFunctionsForAccessPointAsync(accessPoint.Id));
                
                // Iterating over all safety functions of selected access point
                foreach (var safetyFunction in safetyFunctions)
                {
                    SafetyFunctionInfo safetyFunctionInfo = new()
                    {
                        SafetyFunctionId = safetyFunction.Id,
                        SafetyFunctionName = safetyFunction.Name,
                        SafetyFunctionState = safetyFunction.CurrentState,
                    };
                    accessPointInfo.SafetyFunctions.Add(safetyFunctionInfo);
                }
                // Adding selected access point with its safety functions to main model which will be returned
                model.AccessPoints.Add(accessPointInfo);
            }
            return model;
        }

        private async Task<TypeOfLogicModel> SelectLogicAsync(uint standardInputs, uint standardOutputs)
        {
            ICollection<TypeOfLogicModel> typeOfLogics = await codeListFacade.GetAllAsync("TypeOfLogic");
            if (typeOfLogics is null)
                return null;

            // Relay
            if (standardInputs <= 4 && standardOutputs <= 4)
                return typeOfLogics.FirstOrDefault(tol => tol.Id == 1);

            // CR30
            else if (standardInputs <= 12 && standardOutputs <= 10)
                return typeOfLogics.FirstOrDefault(tol => tol.Id == 2);

            // GMX
            else if (standardInputs + standardOutputs <= 6144)
                return typeOfLogics.FirstOrDefault(tol => tol.Id == 3);

            // GLX
            else
                return typeOfLogics.FirstOrDefault(tol => tol.Id == 4);
        }
    }
}
