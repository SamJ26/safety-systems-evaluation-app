using System;
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
        public void Test1()
        {

        }
    }
}
