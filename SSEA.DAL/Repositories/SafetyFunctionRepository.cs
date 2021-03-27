using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SafetyFunctionRepository
    {
        private AppDbContext dbContext;

        private readonly int safetyFunctionNewStateId = 8;

        public SafetyFunctionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<SafetyFunction>> GetAllAsync()
        {
            return await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                  .Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .AsNoTracking()
                                                  .ToListAsync();
        }

        public async Task<SafetyFunction> GetByIdPLAsync(int id)
        {
            // Getting safety function without subsystems
            return await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.PLr)
                                                  .Include(sf => sf.PLresult)
                                                  .Include(sf => sf.S)
                                                  .Include(sf => sf.F)
                                                  .Include(sf => sf.P)
                                                  .AsNoTracking()
                                                  .SingleOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<SafetyFunction> GetByIdSILAsync(int id)
        {
            return await dbContext.SafetyFunctions.Include(sf => sf.CurrentState)
                                                  .Include(sf => sf.TypeOfFunction)
                                                  .Include(sf => sf.EvaluationMethod)
                                                  .Include(sf => sf.SILCL)
                                                  .Include(sf => sf.SILresult)
                                                  .Include(sf => sf.Se)
                                                  .Include(sf => sf.Fr)
                                                  .Include(sf => sf.Pr)
                                                  .Include(sf => sf.Av)
                                                  .AsNoTracking()
                                                  .SingleOrDefaultAsync(sf => sf.Id == id);
        }

        public async Task<ICollection<Subsystem>> GetSubsystemsForSafetyFunctionPLAsync(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                                         .Select(a => a.SubsystemId)
                                                                         .ToArrayAsync();

            var subsystems = await dbContext.Subsystems.Where(s => s.CategoryId != null && subsystemIds.Contains(s.Id))
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.Category)
                                                       .Include(s => s.DCresult)
                                                       .Include(s => s.MTTFdResult)
                                                       .Include(s => s.PLresult)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();
            return subsystems;
        }

        public async Task<ICollection<Subsystem>> GetSubsystemsForSafetyFunctionSILAsync(int safetyFunctionId)
        {
            // Getting ids of all subsystems which are related to selected safety function specified by safetyFunctionId
            int[] subsystemIds = await dbContext.SafetyFunctionSubsystems.Where(a => a.SafetyFunctionId == safetyFunctionId)
                                                                         .Select(a => a.SubsystemId)
                                                                         .ToArrayAsync();

            var subsystems = await dbContext.Subsystems.Where(s => s.ArchitectureId != null && subsystemIds.Contains(s.Id))
                                                       .Include(s => s.TypeOfSubsystem)
                                                       .Include(s => s.Architecture)
                                                       .Include(s => s.PFHdResult)
                                                       .Include(s => s.CFF)
                                                       .Include(s => s.CurrentState)
                                                       .AsNoTracking()
                                                       .ToListAsync();
            return subsystems;
        }
    }
}
