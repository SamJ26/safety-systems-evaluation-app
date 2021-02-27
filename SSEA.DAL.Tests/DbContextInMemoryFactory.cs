using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL.Tests
{
    public class DbContextInMemoryFactory : IDbContextFactory<AppDbContext>
    {
        private readonly string dbName;

        public DbContextInMemoryFactory(string dbName)
        {
            this.dbName = dbName;
        }

        public AppDbContext CreateDbContext()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            contextOptionsBuilder.UseInMemoryDatabase(dbName);
            var createdDbContext = new AppDbContext(contextOptionsBuilder.Options);
            createdDbContext.Database.EnsureCreated();
            return createdDbContext;
        }
    }
}
