using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
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
            return await dbContext.AccessPoints.AsNoTracking().ToListAsync();
        }
    }
}
