using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Repositories
{
    public class MachineRepository
    {
        private readonly AppDbContext dbContext;

        public MachineRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
