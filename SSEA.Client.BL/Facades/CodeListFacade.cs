using Newtonsoft.Json;
using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
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

        // TODO: uncomment methods after adding all models to client service

        public async Task<ICollection<OperationPrincipleModel>> GetAllOperationPrinciplesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("OperationPrinciple");
            Console.WriteLine($"Fetching data - OperationPrinciple - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<OperationPrincipleModel>>(response.Data);
        }

        public async Task<ICollection<CCFModel>> GetAllCCFsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("CCF");
            Console.WriteLine($"Fetching data - CCF - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<CCFModel>>(response.Data);
        }

        public async Task<ICollection<DCModel>> GetAllDCsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("DC");
            Console.WriteLine($"Fetching data - DC - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<DCModel>>(response.Data);
        }

        public async Task<ICollection<EvaluationMethodModel>> GetAllEvaluationMethodsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("EvaluationMethod");
            Console.WriteLine($"Fetching data - EvaluationMethod - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<EvaluationMethodModel>>(response.Data);
        }

        public async Task<ICollection<MachineTypeModel>> GetAllMachineTypesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("MachineType");
            Console.WriteLine($"Fetching data - MachineType - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<MachineTypeModel>>(response.Data);
        }

        public async Task<ICollection<NormModel>> GetAllNormsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Norm");
            Console.WriteLine($"Fetching data - Norm - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<NormModel>>(response.Data);
        }

        public async Task<ICollection<TypeOfFunctionModel>> GetAllTypeOfFunctionsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("TypeOfFunction");
            Console.WriteLine($"Fetching data - TypeOfFunction - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<TypeOfFunctionModel>>(response.Data);
        }

        public async Task<ICollection<TypeOfLogicModel>> GetAllTypeOfLogicsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("TypeOfLogic");
            Console.WriteLine($"Fetching data - TypeOfLogic - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<TypeOfLogicModel>>(response.Data);
        }

        public async Task<ICollection<TypeOfSubsystemModel>> GetAllTypeOfSubsystemsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("TypeOfSubsystem");
            Console.WriteLine($"Fetching data - TypeOfSubsystem - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<TypeOfSubsystemModel>>(response.Data);
        }

        public async Task<ICollection<CategoryModel>> GetAllCategoriesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Category");
            Console.WriteLine($"Fetching data - Category - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<CategoryModel>>(response.Data);
        }

        public async Task<ICollection<FModel>> GetAllFsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("F");
            Console.WriteLine($"Fetching data - F - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<FModel>>(response.Data);
        }

        public async Task<ICollection<MTTFdModel>> GetAllMTTFdsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("MTTFd");
            Console.WriteLine($"Fetching data - MTTFd - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<MTTFdModel>>(response.Data);
        }

        public async Task<ICollection<PLModel>> GetAllPLsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("PL");
            Console.WriteLine($"Fetching data - PL - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<PLModel>>(response.Data);
        }

        public async Task<ICollection<PModel>> GetAllPsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("P");
            Console.WriteLine($"Fetching data - P - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<PModel>>(response.Data);
        }

        public async Task<ICollection<SModel>> GetAllSsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("S");
            Console.WriteLine($"Fetching data - S - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<SModel>>(response.Data);
        }

        public async Task<ICollection<ArchitectureModel>> GetAllArchitecturesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Architecture");
            Console.WriteLine($"Fetching data - Architecture - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<ArchitectureModel>>(response.Data);
        }

        public async Task<ICollection<AvModel>> GetAllAvsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Av");
            Console.WriteLine($"Fetching data - Av - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<AvModel>>(response.Data);
        }

        public async Task<ICollection<FrModel>> GetAllFrsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Fr");
            Console.WriteLine($"Fetching data - Fr - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<FrModel>>(response.Data); ;
        }

        public async Task<ICollection<PFHdModel>> GetAllPFHdsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("PFHd");
            Console.WriteLine($"Fetching data - PFHd - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<PFHdModel>>(response.Data);
        }

        public async Task<ICollection<PrModel>> GetAllPrsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Pr");
            Console.WriteLine($"Fetching data - Pr - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<PrModel>>(response.Data);
        }

        public async Task<ICollection<SeModel>> GetAllSesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Se");
            Console.WriteLine($"Fetching data - Se - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<SeModel>>(response.Data);
        }

        //public async Task<ICollection<SFFModel>> GetAllSFFsAsync()
        //{
        //    var response = await clientService.CodeListGetAllAsync("SFF");
        //    Console.WriteLine($"Fetching data - SFF - Count: {response.Count}");
        //    return JsonConvert.DeserializeObject<ICollection<NormModel>>(response.Data);
        //}

        public async Task<ICollection<ProducerModel>> GetAllProducersAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Producer");
            Console.WriteLine($"Fetching data - Producer - Count: {response.Count}");
            return JsonConvert.DeserializeObject<ICollection<ProducerModel>>(response.Data);
        }
    }
}
