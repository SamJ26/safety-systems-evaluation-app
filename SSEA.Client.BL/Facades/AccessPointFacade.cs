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
    }
}
