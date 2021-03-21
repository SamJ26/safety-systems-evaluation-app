﻿using SSEA.Client.BL.Services;
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
            return await clientService.SafetyFunctionGetAllAsync(0);
        }

        public async Task<ICollection<SafetyFunctionListModel>> GetAllAsync(int accessPointId)
        {
            Console.WriteLine("SafetyFunctionFacade.GetAllAsync(int accessPointId)");
            return await clientService.SafetyFunctionGetAllAsync(accessPointId);
        }

        public async Task<SafetyFunctionDetailModelPL> GetByIdPLAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.GetByIdPLAsync(int id)");
            return await clientService.SafetyFunctionGetByIdPLAsync(id);
        }

        public async Task<SafetyFunctionDetailModelSIL> GetByIdSILAsync(int id)
        {
            Console.WriteLine("SafetyFunctionFacade.GetByIdSILAsync(int id)");
            return await clientService.SafetyFunctionGetByIdSILAsync(id);
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelPL newModel)
        {
            Console.WriteLine("SafetyFunctionFacade.CreateAsync(SafetyFunctionDetailModelPL newModel)");
            return await clientService.SafetyFunctionCreatePLAsync(newModel);
        }

        public async Task<int> CreateAsync(SafetyFunctionDetailModelSIL newModel)
        {
            Console.WriteLine("SafetyFunctionFacade.CreateAsync(SafetyFunctionDetailModelSIL newModel)");
            return await clientService.SafetyFunctionCreateSILAsync(newModel);
        }
    }
}
