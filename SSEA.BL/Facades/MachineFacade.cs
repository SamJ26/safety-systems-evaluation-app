using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.MainModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade
    {
        private readonly IMapper mapper;
        private readonly MachineRepository machineRepository;
        private readonly AccessPointRepository accessPointRepository;

        public MachineFacade(IMapper mapper, MachineRepository machineRepository, AccessPointRepository accessPointRepository)
        {
            this.mapper = mapper;
            this.machineRepository = machineRepository;
            this.accessPointRepository = accessPointRepository;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel, int userId)
        {
            Machine machineEntity = mapper.Map<Machine>(newModel);

            // Saving machine with AccessPoints
            int id = await machineRepository.CreateAsync(machineEntity, userId);

            // Saving related norms
            ICollection<Norm> norms = mapper.Map<ICollection<Norm>>(newModel.Norms);
            await machineRepository.AddNormsToMachineAsync(norms, id);
        
            return id;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync(string machineName, int stateId, int machineTypeId, int evaluationMethodId, int producerId)
        {
            var machines = await machineRepository.GetAllAsync(machineName, stateId, machineTypeId, evaluationMethodId, producerId);
            return mapper.Map<ICollection<MachineListModel>>(machines);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = mapper.Map<MachineDetailModel>(await machineRepository.GetByIdAsync(id));
            machine.Norms = mapper.Map<HashSet<NormModel>>(await machineRepository.GetNormsForMachineAsync(id));
            return machine;
        }

        public async Task<int> UpdateAsync(MachineDetailModel updatedModel, int userId)
        {
            // Getting unchanged machine from database to compare with updated model
            MachineDetailModel oldModel = await GetByIdAsync(updatedModel.Id);

            #region Processing norms

            ICollection<NormModel> addedNorms = new List<NormModel>();

            // After this foreach, oldModel.Norms will contain norms which should be removed
            foreach (var norm in updatedModel.Norms.ToList())
            {
                NormModel foundNorm = oldModel.Norms.FirstOrDefault(n => n.Id == norm.Id);

                // Item was not removed / added
                if (foundNorm is not null)
                    oldModel.Norms.Remove(foundNorm);

                // Item was added
                else if (foundNorm is null)
                    addedNorms.Add(norm);
            }

            // Removing norms
            foreach (var norm in oldModel.Norms)
                await machineRepository.RemoveNormAsync(updatedModel.Id, norm.Id);

            // Adding new norms to machine
            if (addedNorms.Count != 0)
                await machineRepository.AddNormsToMachineAsync(mapper.Map<ICollection<Norm>>(addedNorms), updatedModel.Id);

            // Norms are processed -> can be cleared
            updatedModel.Norms.Clear();

            #endregion

            #region Processing access points

            // After this foreach, oldModel.AccessPoints will contain access points which should be removed
            foreach (var accessPoint in updatedModel.AccessPoints.ToList())
            {
                AccessPointListModel foundAccessPoint = oldModel.AccessPoints.FirstOrDefault(ap => ap.Id == accessPoint.Id);

                // Item was not removed / added
                if (foundAccessPoint is not null)
                    oldModel.AccessPoints.Remove(foundAccessPoint);
            }

            // Removing access points
            foreach (var accessPoint in oldModel.AccessPoints)
            {
                await accessPointRepository.DeleteAsync(accessPoint.Id, userId);
            }

            #endregion

            // Creating machine entity with machine properties and access point collection
            Machine machineEntity = mapper.Map<Machine>(updatedModel);

            return await machineRepository.UpdateAsync(machineEntity, userId);
        }

        // TODO: complete logic for removing
        public async Task DeleteAsync(int machineId, int userId)
        {
            await machineRepository.DeleteAsync(machineId, userId);
        }

        public async Task<MachineEvaluationResponseModel> SelectLogicAsync(int machineId, int userId)
        {
            return new MachineEvaluationResponseModel();
        }
    }
}
