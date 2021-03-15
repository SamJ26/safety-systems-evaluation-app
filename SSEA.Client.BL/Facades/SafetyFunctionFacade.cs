using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class SafetyFunctionFacade
    {
        private readonly IClientService clientService;

        public SafetyFunctionFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync()
        {
            Console.WriteLine("SafetyFunctionFacade.GetAllAsync()");
            return new List<SafetyFunctionListModel>();
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(int accessPointId)
        {
            Console.WriteLine("SafetyFunctionFacade.GetAllAsync(int accessPointId)");
            return new List<SafetyFunctionListModel>();
        }
    }
}
