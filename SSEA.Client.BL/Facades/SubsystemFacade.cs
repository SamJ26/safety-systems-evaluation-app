using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<SubsystemCreationResponseModel> CreateAsync(SubsystemDetailModelPL newModel)
        {
            Console.WriteLine("SubsystemFacade.CreateAsync(SubsystemDetailModelPL newModel)");
            return await clientService.SubsystemCreatePLAsync(newModel);
        }
    }
}
