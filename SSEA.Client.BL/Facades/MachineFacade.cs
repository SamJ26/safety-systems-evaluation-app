using SSEA.Client.BL.Services;
using System;
using System.Collections.Generic;
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

        public async Task<MachineLogicSelectionResponseModel> SelectLogicAsync(int id)
        {
            Console.WriteLine("MachineFacade.SelectLogicAsync(int id)");
            return await clientService.MachineSelectLogicAsync(id);
        }

        public async Task<SafetyEvaluationResponseModel> EvaluateSafetyAsync(int id)
        {
            Console.WriteLine("MachineFacade.EvaluateSafety(int id)");
            return await clientService.MachineEvaluateSafetyAsync(id);
        }

        public async Task<MachineSafetySummaryModel> GetMachineSafetySummaryAsync(int id)
        {
            Console.WriteLine("MachineFacade.GetMachineSafetySummaryAsync(int id)");
            return await clientService.MachinGetSafetySummaryAsync(id);
        }
    }
}
