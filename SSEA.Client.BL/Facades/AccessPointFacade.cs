using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
            Console.WriteLine("AccessPointFacade.GetByIdAsync()");
            return await clientService.AccessPointGetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(AccessPointDetailModel updateModel)
        {
            Console.WriteLine("AccessPointFacade.UpdateAsync()");
            return await clientService.AccessPointUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id, bool softDelete = true)
        {
            Console.WriteLine("AccessPointFacade.DeleteAsync()");
            await clientService.AccessPointDeleteAsync(id, softDelete);
        }
    }
}
