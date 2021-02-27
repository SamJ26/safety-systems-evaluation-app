using AutoMapper;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.DAL;
using SSEA.DAL.Tests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SSEA.BL.Tests
{
    public class CodeListFacadeTest : IDisposable
    {
        private readonly IMapper mapper;
        private readonly DbContextInMemoryFactory dbContextFactory;
        private AppDbContext dbContext;

        public CodeListFacadeTest()
        {
            if (mapper == null)
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CCFModelMapperProfile());
                });
                mapper = mapperConfig.CreateMapper();
            }
            dbContextFactory = new DbContextInMemoryFactory(nameof(AppDbContext));
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

        [Fact]
        public async Task GetAllCCFModels()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var facade = new CodeListFacade(mapper, dbContext);
                var data = await facade.GetAllAsync("CCF");
                Type dataType = ((object)data).GetType();
                Assert.True(dataType == typeof(List<CCFModel>));
                Assert.True(data.Count == 5);
            }
        }
    }
}
