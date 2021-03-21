using SSEA.Client.BL.Services;
using System;
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

        public async Task<AccessPointDetailModel> GetByIdAsync(int id)
        {
            return await clientService.AccessPointGetByIdAsync(id);
        }

        public async Task<int> AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            var model = new AccessPointSafetyFunctionModel()
            {
                AccessPointId = accessPointId,
                SafetyFunctionId = safetyFunctionId,
            };
            Console.WriteLine("AccessPointFacade.AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)");
            return await clientService.AccessPointAddSafetyFunctionAsync(model);
        }


        public async Task<int> UpdateAsync(AccessPointDetailModel updateModel)
        {
            Console.WriteLine("AccessPointFacade.UpdateAsync(AccessPointDetailModel updateModel)");
            return await clientService.AccessPointUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id, bool softDelete = true)
        {
            Console.WriteLine("AccessPointFacade.DeleteAsync(int id, bool softDelete = true)");
            await clientService.AccessPointDeleteAsync(id, softDelete);
        }
    }
}
