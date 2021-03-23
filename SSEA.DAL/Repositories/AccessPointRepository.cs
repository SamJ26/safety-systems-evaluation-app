using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class AccessPointRepository
    {
        private readonly AppDbContext dbContext;

        private readonly int accessPointRemovedStateId = 7;

        public AccessPointRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AccessPoint>> GetAllAsync()
        {
            return await dbContext.AccessPoints.Include(ap => ap.CurrentState).AsNoTracking().ToListAsync();
        }

        public async Task<AccessPoint> GetByIdAsync(int id)
        {
            return await dbContext.AccessPoints.Include(ap => ap.CurrentState)
                                               .Include(ap => ap.Machine)
                                                  .ThenInclude(m => m.EvaluationMethod)
                                               .SingleOrDefaultAsync(ap => ap.Id == id);
        }

        public async Task<ICollection<SafetyFunction>> GetSafetyFunctionsForAccessPointAsync(int acessPointId)
        {
            int[] ids = await dbContext.AccessPointSafetyFunctions.Where(apsf => apsf.AccessPointId == acessPointId)
                                                                  .Select(apsf => apsf.SafetyFunctionId)
                                                                  .ToArrayAsync();

            return await dbContext.SafetyFunctions.Where(sf => ids.Contains(sf.Id))
                                                  .AsNoTracking()
                                                  .ToListAsync();
        }
    }
}
