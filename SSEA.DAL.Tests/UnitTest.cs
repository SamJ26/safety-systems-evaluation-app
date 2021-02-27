using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace SSEA.DAL.Tests
{
    public class UnitTest : IDisposable
    {
        private readonly DbContextInMemoryFactory dbContextFactory;
        private AppDbContext dbContext;

        public UnitTest()
        {
            dbContextFactory = new DbContextInMemoryFactory(nameof(AppDbContext));
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

        [Fact]
        public void GetAllDCs()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var data = dbContext.DCs.ToList();
                Assert.True(data.Count == 4);
            }
        }

        [Fact]
        public void GetAllArchitectures()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var data = dbContext.Architectures.Include(a => a.MaxPFHd)
                                                      .ToList();
                Assert.True(data.Count == 4);
            }
        }
    }
}
