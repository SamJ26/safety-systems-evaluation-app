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

        // TODO: uncomment methods after adding all models to client service

        //public async Task<ICollection<CCFModel>> GetAllCCFsAsync()
        //{
        //    var data = await dbContext.CCFs.AsNoTracking().ToListAsync();
        //    return mapper.Map<ICollection<CCFModel>>(data);
        //}

        public async Task<ICollection<DCModel>> GetAllDCsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("DC");
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
            return JsonConvert.DeserializeObject<ICollection<NormModel>>(response.Data);
        }

        public async Task<ICollection<TypeOfFunctionModel>> GetAllTypeOfFunctionsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("TypeOfFunction");
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
            return JsonConvert.DeserializeObject<ICollection<TypeOfSubsystemModel>>(response.Data);
        }

        public async Task<ICollection<CategoryModel>> GetAllCategoriesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Category");
            return JsonConvert.DeserializeObject<ICollection<CategoryModel>>(response.Data);
        }

        public async Task<ICollection<FModel>> GetAllFsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("F");
            return JsonConvert.DeserializeObject<ICollection<FModel>>(response.Data);
        }

        public async Task<ICollection<MTTFdModel>> GetAllMTTFdsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("MTTFd");
            return JsonConvert.DeserializeObject<ICollection<MTTFdModel>>(response.Data);
        }

        public async Task<ICollection<PLModel>> GetAllPLsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("PL");
            return JsonConvert.DeserializeObject<ICollection<PLModel>>(response.Data);
        }

        public async Task<ICollection<PModel>> GetAllPsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("P");
            return JsonConvert.DeserializeObject<ICollection<PModel>>(response.Data);
        }

        public async Task<ICollection<SModel>> GetAllSsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("S");
            return JsonConvert.DeserializeObject<ICollection<SModel>>(response.Data);
        }

        public async Task<ICollection<ArchitectureModel>> GetAllArchitecturesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Architecture");
            return JsonConvert.DeserializeObject<ICollection<ArchitectureModel>>(response.Data);
        }

        public async Task<ICollection<AvModel>> GetAllAvsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Av");
            return JsonConvert.DeserializeObject<ICollection<AvModel>>(response.Data);
        }

        public async Task<ICollection<CFFModel>> GetAllCFFsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("CFF");
            return JsonConvert.DeserializeObject<ICollection<CFFModel>>(response.Data);
        }

        public async Task<ICollection<FrModel>> GetAllFrsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Fr");
            return JsonConvert.DeserializeObject<ICollection<FrModel>>(response.Data); ;
        }

        public async Task<ICollection<PFHdModel>> GetAllPFHdsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("PFHd");
            return JsonConvert.DeserializeObject<ICollection<PFHdModel>>(response.Data);
        }

        public async Task<ICollection<PrModel>> GetAllPrsAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Pr");
            return JsonConvert.DeserializeObject<ICollection<PrModel>>(response.Data);
        }

        public async Task<ICollection<SeModel>> GetAllSesAsync()
        {
            var response = await clientService.CodeListGetAllAsync("Se");
            return JsonConvert.DeserializeObject<ICollection<SeModel>>(response.Data);
        }

        //public async Task<ICollection<SFFModel>> GetAllSFFsAsync()
        //{
        //    var response = await clientService.CodeListGetAllAsync("Norm");
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
