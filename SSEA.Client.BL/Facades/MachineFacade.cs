using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class MachineFacade
    {
        private readonly IClientService clientService;

        public MachineFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            return await clientService.MachineGetAllAsync();
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            return await clientService.MachineGetByIdAsync(id);
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            return await clientService.MachineCreateAsync(newModel);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updateModel)
        {
            return await clientService.MachineUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id)
        {
            await clientService.MachineDeleteAsync(id);
        }
    }
}
