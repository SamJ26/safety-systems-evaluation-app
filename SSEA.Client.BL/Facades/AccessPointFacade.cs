using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class AccessPointFacade
    {
        private readonly IClientService clientService;

        public AccessPointFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<ICollection<AccessPointListModel>> GetAllAsync()
        {
            Console.WriteLine("AccessPointFacade.GetAllAsync()");
            return await clientService.AccessPointGetAllAsync();
        }

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            Console.WriteLine("AccessPointFacade.GetByIdAsync(int id)");
            return await clientService.AccessPointGetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(AccessPointDetailModel updateModel)
        {
            Console.WriteLine("AccessPointFacade.UpdateAsync(AccessPointDetailModel updateModel)");
            return await clientService.AccessPointUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("AccessPointFacade.DeleteAsync(int id)");
            await clientService.AccessPointDeleteAsync(id);
        }

        public async Task AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            Console.WriteLine("AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)");
            await clientService.AccessPointAddSafetyFunctionAsync(accessPointId, safetyFunctionId);
        }

        public async Task RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            Console.WriteLine("RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId)");
            await clientService.AccessPointRemoveSafetyFunctionAsync(accessPointId, safetyFunctionId);
        }
    }
}
