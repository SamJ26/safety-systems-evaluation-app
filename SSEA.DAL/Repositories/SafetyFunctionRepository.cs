using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Repositories
{
    public class SafetyFunctionRepository
    {
        private AppDbContext dbContext;

        public SafetyFunctionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
