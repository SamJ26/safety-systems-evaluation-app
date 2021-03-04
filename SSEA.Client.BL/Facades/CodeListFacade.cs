using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.Client.BL.Facades
{
    public class CodeListFacade
    {
        private readonly IClientService clientService;

        public CodeListFacade(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<dynamic> GetAllAsync(string typeName)
        {
            string json = await clientService.CodeListGetAllAsync(typeName);
            dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
            return data;
        }
    }
}
