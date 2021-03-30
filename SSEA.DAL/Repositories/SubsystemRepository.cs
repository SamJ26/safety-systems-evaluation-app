using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSEA.DAL.Repositories
{
    public class SubsystemRepository
    {
        private readonly AppDbContext dbContext;

        public SubsystemRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Subsystem>> GetAllAsync()
        {
            return new List<Subsystem>();
        }
    }
}
