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

        // TODO: add filter options
        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            Console.WriteLine("MachineFacade.GetAllAsync()");
            return await clientService.MachineGetAllAsync();
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            Console.WriteLine("MachineFacade.GetAllAsync()");
            return await clientService.MachineGetByIdAsync(id);
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            Console.WriteLine("MachineFacade.CreateAsync()");
            return await clientService.MachineCreateAsync(newModel);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updateModel)
        {
            Console.WriteLine("MachineFacade.UpdateAsync()");
            return await clientService.MachineUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("MachineFacade.DeleteAsync()");
            await clientService.MachineDeleteAsync(id);
        }
    }
}
