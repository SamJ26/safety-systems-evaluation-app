using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.BL.Services.Interfaces;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.JoinEntities;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SubsystemFacade
    {
        private readonly IMapper mapper;
        private readonly SubsystemRepository subsystemRepository;
        private readonly IPerformanceLevelService PLService;

        public SubsystemFacade(IMapper mapper, SubsystemRepository subsystemRepository, IPerformanceLevelService PLService)
        {
            this.mapper = mapper;
            this.subsystemRepository = subsystemRepository;
            this.PLService = PLService;
        }

        public async Task<ICollection<SubsystemListModelPL>> GetAllPLAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int categoryId, int performanceLevelId)
        {
            var subsystems = await subsystemRepository.GetAllPLAsync(stateId, typeOfSubsystemId, operationPrincipleId, categoryId, performanceLevelId);
            return mapper.Map<ICollection<SubsystemListModelPL>>(subsystems);
        }

        public async Task<ICollection<SubsystemListModelSIL>> GetAllSILAsync(int stateId, int typeOfSubsystemId, int operationPrincipleId, int architectureId, int silId)
        {
            var subsystems = await subsystemRepository.GetAllSILAsync(stateId, typeOfSubsystemId, operationPrincipleId, architectureId, silId);
            return mapper.Map<ICollection<SubsystemListModelSIL>>(subsystems);
        }

        //public async Task<SubsystemDetailModelPL> GetByIdPLAsync(int id)
        //{
        //    var subsystem = await dbContext.Subsystems.Where(s => s.CategoryId != null)
        //                                              .Include(s => s.TypeOfSubsystem)
        //                                              .Include(s => s.Category)
        //                                              .Include(s => s.DCresult)
        //                                              .Include(s => s.MTTFdResult)
        //                                              .Include(s => s.PLresult)
        //                                              .Include(s => s.CurrentState)
        //                                              .AsNoTracking()
        //                                              .SingleOrDefaultAsync(s => s.Id == id);

        //    var model = mapper.Map<SubsystemDetailModelPL>(subsystem);

        //    // Getting all CCFs related to selected subsystem
        //    int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == id)
        //                                                  .Select(a => a.CCFId)
        //                                                  .ToArrayAsync();
        //    if (foundIds.Count() != 0)
        //    {
        //        var foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
        //        model.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(foundCCFs);
        //    }
        //    return model;
        //}

        //public async Task<SubsystemDetailModelSIL> GetByIdSILAsync(int id)
        //{
        //    var subsystem = await dbContext.Subsystems.Where(s => s.ArchitectureId != null)
        //                                              .Include(s => s.TypeOfSubsystem)
        //                                              .Include(s => s.Architecture)
        //                                              .Include(s => s.PFHdResult)
        //                                              .Include(s => s.CFF)
        //                                              .Include(s => s.CurrentState)
        //                                              .AsNoTracking()
        //                                              .SingleOrDefaultAsync(s => s.Id == id);

        //    var model = mapper.Map<SubsystemDetailModelSIL>(subsystem);

        //    // Getting all CCFs related to selected subsystem
        //    int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == id)
        //                                                  .Select(a => a.CCFId)
        //                                                  .ToArrayAsync();
        //    if (foundIds.Count() != 0)
        //    {
        //        var foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
        //        model.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(foundCCFs);
        //    }
        //    return model;
        //}

        //// TODO: add logic
        //public async Task<int> CreateAsync(SubsystemDetailModelPL model, int userId)
        //{
        //    // Number of elements must be equal to number of channels of given category
        //    if (model.Category.Channels != model.Elements.Count)
        //        return 0;

        //    // Evaluation of all imporatant properties of subsystem (couting MTTFd, DC, checking CCF ...)
        //    await PLService.EvaluateSubsystem(model);

        //    // Creating subsystem entity from model
        //    var entity = mapper.Map<Subsystem>(model);

        //    // Validation of subsystem before calling SaveChanges
        //    if (PLService.IsSubsystemValid(model))
        //    {
        //        await dbContext.AddAsync(entity);
        //        await dbContext.SaveChangesAsync();
        //        return entity.Id;
        //    }
        //    return 0;
        //}

        //// TODO: add logic
        //public async Task<int> CreateAsync(SubsystemDetailModelSIL model, int userId)
        //{
        //    // Number of elements must be equal to number of channels of given category
        //    if (model.Architecture.Channels != model.Elements.Count)
        //        return 0;

        //    return 0;
        //}
    }
}
