using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class MachineFacade
    {
        private readonly IMapper mapper;
        private readonly MachineRepository repository;

        public MachineFacade(IMapper mapper, MachineRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<int> CreateAsync(MachineDetailModel newModel, int userId)
        {
            Machine machineEntity = mapper.Map<Machine>(newModel);

            // Saving machine with AccessPoints
            int id = await repository.CreateAsync(machineEntity, userId);

            // Saving related norms
            ICollection<Norm> norms = mapper.Map<ICollection<Norm>>(newModel.Norms);
            await repository.AddNormsToMachineAsync(norms, id);
        
            return id;
        }

        public async Task<ICollection<MachineListModel>> GetAllAsync()
        {
            var machines = await repository.GetAllAsync();
            return mapper.Map<ICollection<MachineListModel>>(machines);
        }

        public async Task<MachineDetailModel> GetByIdAsync(int id)
        {
            var machine = mapper.Map<MachineDetailModel>(await repository.GetByIdAsync(id));
            machine.Norms = mapper.Map<HashSet<NormModel>>(await repository.GetNormsForMachineAsync(id));
            return machine;
        }

        // TODO: add logic for removing access points
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
                await repository.RemoveNormAsync(updatedModel.Id, norm.Id);

            // Adding new norms to machine
            if (addedNorms.Count != 0)
                await repository.AddNormsToMachineAsync(mapper.Map<ICollection<Norm>>(addedNorms), updatedModel.Id);

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

            // Removing norms
            foreach (var accessPoint in oldModel.AccessPoints)
            {
                // TODO: remove access points using access point facade ??
            }

            #endregion

            // Creating machine entity with machine properties and access point collection
            Machine machineEntity = mapper.Map<Machine>(updatedModel);

            return await repository.UpdateAsync(machineEntity, userId);
        }

        // TODO: GetAll method with filter
        // TODO: Delete method
    }
}
