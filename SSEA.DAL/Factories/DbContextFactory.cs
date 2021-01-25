using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Factories
{
    public class DbContextFactory : IDbContextFactory<AppDbContext>
    {
        private readonly string connectionString;

        public DbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var dbContext = new AppDbContext(optionsBuilder.Options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
