using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace SSEA.DAL.Tests
{
    public class UnitTest : IDisposable
    {
        private readonly DbContextInMemoryFactory dbContextFactory;
        private readonly AppDbContext dbContext;

        public UnitTest()
        {
            dbContextFactory = new DbContextInMemoryFactory(nameof(AppDbContext));
            dbContext = dbContextFactory.CreateDbContext();
            dbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

        [Fact]
        public void GetAllDCs()
        {
            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var data = tempDbContext.DCs.ToList();
                Assert.True(data.Count == 4);
            }
        }

        [Fact]
        public void GetAllArchitectures()
        {
            using (var tempDbContext = dbContextFactory.CreateDbContext())
            {
                var data = tempDbContext.Architectures.Include(a => a.MaxPFHd)
                                                      .ToList();
                Assert.True(data.Count == 4);
            }
        }
    }
}
