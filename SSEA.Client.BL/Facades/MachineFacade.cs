﻿using SSEA.Client.BL.Services;
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

        // TODO: add getallmethod with filter

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            Console.WriteLine("MachineFacade.GetAllAsync()");
            return await clientService.MachineGetAllAsync();
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

        public async Task RemoveNormAsync(int machineId, int normId)
        {
            Console.WriteLine("MachineFacade.RemoveNormAsync(int machineId, int normId)");
            await clientService.MachineRemoveNormAsync(machineId, normId);
        }


        public async Task<int> UpdateAsync(MachineDetailModel updateModel)
        {
            Console.WriteLine("MachineFacade.UpdateAsync(MachineDetailModel updateModel)");
            // return await clientService.MachineUpdateAsync(updateModel);
            return 0;
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("MachineFacade.DeleteAsync(int id)");
            // await clientService.MachineDeleteAsync(id);
        }
    }
}
