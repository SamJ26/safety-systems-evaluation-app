using AutoMapper;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
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
                    mc.AddProfile(new TypeOfLogicModelMapperProfile());
                    mc.AddProfile(new ArchitectureModelMapperProfile());
                    mc.AddProfile(new CategoryModelMapperProfile());
                    mc.AddProfile(new PFHdModelMapperProfile());
                    mc.AddProfile(new PLModelMapperProfile());
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
        public async Task GetAllCCFs()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var facade = new CodeListFacade(mapper, dbContext);
                var data = await facade.GetAllAsync("CCF");
                Type dataType = ((object)data).GetType();
                Assert.True(dataType == typeof(List<CCFModel>));
                Assert.True(data.Count > 0);
            }
        }

        [Fact]
        public async Task GetAllTypeOfLogics()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var facade = new CodeListFacade(mapper, dbContext);
                List<TypeOfLogicModel> data = await facade.GetAllAsync("TypeOfLogic");
                foreach (var item in data)
                {
                    Assert.True(item.MaxPL != null);
                    Assert.True(item.MaxArchitecture != null);
                    Assert.True(item.MaxSIL != null);
                    Assert.True(item.MaxCategory != null);
                }
                Assert.True(data.Count == 4);
            }
        }

        [Fact]
        public async Task GetAllArchitectures()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                var facade = new CodeListFacade(mapper, dbContext);
                List<ArchitectureModel> data = await facade.GetAllAsync("Architecture");
                foreach (var item in data)
                {
                    Assert.True(item.MaxPFHd != null);
                }
                Assert.True(data.Count == 4);
            }
        }
    }
}
