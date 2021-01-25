using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Factories
{
    public interface IDbContextFactory<TDbContext> where TDbContext : DbContext
    {
        TDbContext CreateDbContext();
    }
}
