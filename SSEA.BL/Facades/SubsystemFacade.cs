using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
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

        public SubsystemFacade(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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
            var subsystem = await dbContext.Subsystems.Where(s => s.CategoryId != null && s.Id == id)
                                                      .Include(s => s.TypeOfSubsystem)
                                                      .Include(s => s.Category)
                                                      .Include(s => s.DCresult)
                                                      .Include(s => s.MTTFdResult)
                                                      .Include(s => s.PLresult)
                                                      .Include(s => s.CurrentState)
                                                      .AsNoTracking()
                                                      .ToListAsync();

            return mapper.Map<SubsystemDetailModelPL>(subsystem);
        }

        public async Task<SubsystemDetailModelSIL> GetByIdSILAsync(int id)
        {
            var subsystem = await dbContext.Subsystems.Where(s => s.ArchitectureId != null && s.Id == id)
                                                      .Include(s => s.TypeOfSubsystem)
                                                      .Include(s => s.Architecture)
                                                      .Include(s => s.PFHdResult)
                                                      .Include(s => s.CFF)
                                                      .Include(s => s.CurrentState)
                                                      .AsNoTracking()
                                                      .ToListAsync();

            return mapper.Map<SubsystemDetailModelSIL>(subsystem);
        }

        public async Task<int> CreatePLAsync(SubsystemDetailModelPL model)
        {
            // Number of elements must be equal to number of channels of given category
            if (model.Category.Channels != model.Elements.Count)
                return 0;

            // Skontrolovať či je validné CCF
            // Skontrolovať či výsledné MTTFd a DC ktoré výjde z elementov vyhovuje danej kategórii

            return 0;
        }
    }
}
