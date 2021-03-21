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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class SubsystemFacade
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IPerformanceLevelService PLService;

        public SubsystemFacade(AppDbContext dbContext, IMapper mapper, IPerformanceLevelService PLService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.PLService = PLService;
        }

        public async Task<ICollection<SubsystemDetailModelPL>> GetAllPLAsync()
        {
            var subsystems = await dbContext.Subsystems.Where(s => s.CategoryId != null)
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.Category)
                                                       .Include(s => s.DCresult)
                                                       .Include(s => s.MTTFdResult)
                                                       .Include(s => s.PLresult)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();

            return mapper.Map<ICollection<SubsystemDetailModelPL>>(subsystems);
        }

        public async Task<ICollection<SubsystemDetailModelSIL>> GetAllSILAsync()
        {
            var subsystems = await dbContext.Subsystems.Where(s => s.ArchitectureId != null)
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.Architecture)
                                                       .Include(s => s.PFHdResult)
                                                       .Include(s => s.CFF)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();

            return mapper.Map<ICollection<SubsystemDetailModelSIL>>(subsystems);
        }

        public async Task<ICollection<SubsystemDetailModelPL>> GetAllPLAsync(int safetyFunctionId)
        {
            // Getting all subsystems for PL which are related to selected safety function specified by safetyFunctionId
            int[] subsystems = await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                                       .Select(a => a.SubsystemId)
                                                                       .ToArrayAsync();

            var data = await dbContext.Subsystems.Where(s => s.CategoryId != null && subsystems.Contains(s.Id))
                                                 .Include(s => s.TypeOfSubsystem)
                                                 .Include(s => s.Category)
                                                 .Include(s => s.DCresult)
                                                 .Include(s => s.MTTFdResult)
                                                 .Include(s => s.PLresult)
                                                 .Include(s => s.CurrentState)
                                                 .AsNoTracking()
                                                 .ToListAsync();

            return mapper.Map<ICollection<SubsystemDetailModelPL>>(data);
        }

        public async Task<ICollection<SubsystemDetailModelSIL>> GetAllSILAsync(int safetyFunctionId)
        {
            // Getting all subsystems for SIL which are related to selected safety function specified by safetyFunctionId
            int[] subsystems = await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                                       .Select(a => a.SubsystemId)
                                                                       .ToArrayAsync();

            var data = await dbContext.Subsystems.Where(s => s.ArchitectureId != null && subsystems.Contains(s.Id))
                                                 .Include(s => s.TypeOfSubsystem)
                                                 .Include(s => s.Architecture)
                                                 .Include(s => s.PFHdResult)
                                                 .Include(s => s.CFF)
                                                 .Include(s => s.CurrentState)
                                                 .AsNoTracking()
                                                 .ToListAsync();

            return mapper.Map<ICollection<SubsystemDetailModelSIL>>(data);
        }

        public async Task<SubsystemDetailModelPL> GetByIdPLAsync(int id)
        {
            var subsystem = await dbContext.Subsystems.Where(s => s.CategoryId != null)
                                                      .Include(s => s.TypeOfSubsystem)
                                                      .Include(s => s.Category)
                                                      .Include(s => s.DCresult)
                                                      .Include(s => s.MTTFdResult)
                                                      .Include(s => s.PLresult)
                                                      .Include(s => s.CurrentState)
                                                      .AsNoTracking()
                                                      .SingleOrDefaultAsync(s => s.Id == id);

            var model = mapper.Map<SubsystemDetailModelPL>(subsystem);

            // Getting all CCFs related to selected subsystem
            int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == id)
                                                          .Select(a => a.CCFId)
                                                          .ToArrayAsync();
            if (foundIds.Count() != 0)
            {
                var foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
                model.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(foundCCFs);
            }
            return model;
        }

        public async Task<SubsystemDetailModelSIL> GetByIdSILAsync(int id)
        {
            var subsystem = await dbContext.Subsystems.Where(s => s.ArchitectureId != null)
                                                      .Include(s => s.TypeOfSubsystem)
                                                      .Include(s => s.Architecture)
                                                      .Include(s => s.PFHdResult)
                                                      .Include(s => s.CFF)
                                                      .Include(s => s.CurrentState)
                                                      .AsNoTracking()
                                                      .SingleOrDefaultAsync(s => s.Id == id);

            var model = mapper.Map<SubsystemDetailModelSIL>(subsystem);

            // Getting all CCFs related to selected subsystem
            int[] foundIds = await dbContext.SubsystemCCFs.Where(a => a.SubsystemId == id)
                                                          .Select(a => a.CCFId)
                                                          .ToArrayAsync();
            if (foundIds.Count() != 0)
            {
                var foundCCFs = await dbContext.CCFs.Where(c => foundIds.Contains(c.Id)).ToListAsync();
                model.SelectedCCFs = mapper.Map<HashSet<CCFModel>>(foundCCFs);
            }
            return model;
        }

        // TODO: add logic
        public async Task<int> CreateAsync(SubsystemDetailModelPL model, int userId)
        {
            // Number of elements must be equal to number of channels of given category
            if (model.Category.Channels != model.Elements.Count)
                return 0;

            // Evaluation of all imporatant properties of subsystem (couting MTTFd, DC, checking CCF ...)
            await PLService.EvaluateSubsystem(model);

            // Creating subsystem entity from model
            var entity = mapper.Map<Subsystem>(model);

            // Validation of subsystem before calling SaveChanges
            if (PLService.IsSubsystemValid(model))
            {
                await dbContext.AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return entity.Id;
            }
            return 0;
        }

        // TODO: add logic
        public async Task<int> CreateAsync(SubsystemDetailModelSIL model, int userId)
        {
            // Number of elements must be equal to number of channels of given category
            if (model.Architecture.Channels != model.Elements.Count)
                return 0;

            return 0;
        }
    }
}
