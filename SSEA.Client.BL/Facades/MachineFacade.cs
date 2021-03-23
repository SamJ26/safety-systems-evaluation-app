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

        public async Task<ICollection<MachineListModel>> GetAllAsync(string machineName, int stateId, int machineTypeId, int evaluationMethodId, int producerId)
        {
            Console.WriteLine("MachineFacade.GetAllAsync(string machineName, int stateId, int machineTypeId, int evaluationMethodId, int producerId)");
            return await clientService.MachineGetAllAsync(machineName, stateId, machineTypeId, evaluationMethodId, producerId);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            Console.WriteLine("MachineFacade.GetByIdAsync(int id)");
            return await clientService.MachineGetByIdAsync(id);
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel)
        {
            Console.WriteLine("MachineFacade.CreateAsync(MachineDetailModel newModel)");
            return await clientService.MachineCreateAsync(newModel);
        }

        public async Task<int> UpdateAsync(MachineDetailModel updateModel)
        {
            Console.WriteLine("MachineFacade.UpdateAsync(MachineDetailModel updateModel)");
            return await clientService.MachineUpdateAsync(updateModel);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("MachineFacade.DeleteAsync(int id)");
            await clientService.MachineDeleteAsync(id);
        }
    }
}
