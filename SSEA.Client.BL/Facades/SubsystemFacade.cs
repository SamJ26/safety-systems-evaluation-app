using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class SubsystemFacade
    {
        private readonly IClientService clientService;

        public SubsystemFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<SubsystemDetailModelPL> GetByIdPLAsync(int id)
        {
            Console.WriteLine("SubsystemFacade.GetByIdPLAsync(int id)");
            return await clientService.SubsystemGetByIdPLAsync(id);
        }

        public async Task<SubsystemDetailModelSIL> GetByIdSILAsync(int id)
        {
            Console.WriteLine("SubsystemFacade.GetByIdSILAsync(int id)");
            return await clientService.SubsystemGetByIdSILAsync(id);
        }

        public async Task<ICollection<SubsystemListModelPL>> GetAllPLAsync(int stateId = 0, int typeOfSubsystemId = 0, int operationPrincipleId = 0, int categoryId = 0, int performanceLevelId = 0)
        {
            Console.WriteLine("SubsystemFacade.GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)");
            return await clientService.SubsystemGetAllPLAsync(stateId, typeOfSubsystemId, operationPrincipleId, categoryId, performanceLevelId);
        }

        public async Task<ICollection<SubsystemListModelSIL>> GetAllSILAsync(int stateId = 0, int typeOfSubsystemId = 0, int operationPrincipleId = 0, int architectureId = 0, int silId = 0)
        {
            Console.WriteLine("SubsystemFacade.GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)");
            return await clientService.SubsystemGetAllSILAsync(stateId, typeOfSubsystemId, operationPrincipleId, architectureId, silId);
        }

        public async Task<SubsystemCreationResponseModel> CreateAsync(SubsystemDetailModelPL newModel, int safetyFunctionId = 0)
        {
            Console.WriteLine("SubsystemFacade.CreateAsync(SubsystemDetailModelPL newModel, int safetyFunctionId = 0)");
            return await clientService.SubsystemCreatePLAsync(safetyFunctionId, newModel);
        }

        // TODO: Create subsystem SIL

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("SubsystemFacade.DeleteAsync(int id)");
            await clientService.SubsystemDeleteAsync(id);
        }
    }
}
