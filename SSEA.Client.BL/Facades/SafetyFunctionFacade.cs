using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class SafetyFunctionFacade
    {
        private readonly IClientService clientService;

        public SafetyFunctionFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(string name, int stateId, int typeOfFunctionId, int evaluationMethodId)
        {
            Console.WriteLine("SafetyFunctionFacade.GetAllAsync(string name, int stateId, int typeOfFunctionId, int evaluationMethodId)");
            return await clientService.SafetyFunctionGetAllAsync(name, stateId, typeOfFunctionId, evaluationMethodId);
        }

        public async Task<SafetyFunctionDetailModelPL> GetByIdPLAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.GetByIdPLAsync(int id)");
            return await clientService.SafetyFunctionGetByIdPLAsync(id);
        }

        public async Task<SafetyFunctionDetailModelSIL> GetByIdSILAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.GetByIdSILAsync(int id)");
            return await clientService.SafetyFunctionGetByIdSILAsync(id);
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel, int accessPointId = 0)
        {
            Console.WriteLine("SafetyFunctionFacade.CreateAsync(SafetyFunctionDetailModelPL newModel, int accessPointId = 0)");
            return await clientService.SafetyFunctionCreatePLAsync(accessPointId, newModel);
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel, int accessPointId = 0)
        {
            Console.WriteLine("SafetyFunctionFacade.CreateAsync(SafetyFunctionDetailModelSIL newModel)");
            return await clientService.SafetyFunctionCreateSILAsync(accessPointId, newModel);
        }

        public async Task<int> UpdateAsync(SafetyFunctionDetailModelPL updateModel)
        {
            Console.WriteLine("SafetyFunctionFacade.UpdateAsync(SafetyFunctionDetailModelPL updateModel)");
            return await clientService.SafetyFunctionUpdatePLAsync(updateModel);
        }

        public async Task<int> UpdateAsync(SafetyFunctionDetailModelSIL updateModel)
        {
            Console.WriteLine("SafetyFunctionFacade.UpdateAsync(SafetyFunctionDetailModelSIL updateModel)");
            return await clientService.SafetyFunctionUpdateSILAsync(updateModel);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.DeleteAsync(int id)");
            await clientService.SafetyFunctionDeleteAsync(id);
        }

        public async Task AddSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            Console.WriteLine("SafetyFunctionFacade.AddSubsystemAsync(int safetyFunctionId, int subsystemId)");
            await clientService.SafetyFunctionAddSubsystemAsync(safetyFunctionId, subsystemId);
        }

        public async Task RemoveSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            Console.WriteLine("SafetyFunctionFacade.RemoveSubsystemAsync(int safetyFunctionId, int subsystemId)");
            await clientService.SafetyFunctionRemoveSubsystemAsync(safetyFunctionId, subsystemId);
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyFunctionPLAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.EvaluateSafetyFunctionPLAsync(int id)");
            return await clientService.SafetyFunctionEvaluatePLAsync(id);
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyFunctionSILAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.EvaluateSafetyFunctionSILAsync(int id)");
            return await clientService.SafetyFunctionEvaluateSILAsync(id);
        }
    }
}
