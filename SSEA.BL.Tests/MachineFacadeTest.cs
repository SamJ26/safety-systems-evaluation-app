using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SSEA.BL.Tests
{
    public class MachineFacadeTest : IDisposable
    {
        private readonly IMapper mapper;
        private readonly DbContextInMemoryFactory dbContextFactory;
        private AppDbContext dbContext;

        public MachineFacadeTest()
        {
            if (mapper == null)
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MachineDetailModelMapperProfile());
                    mc.AddProfile(new MachineListModelMapperProfile());
                    mc.AddProfile(new EvaluationMethodModelMapperProfile());
                    mc.AddProfile(new MachineTypeModelMapperProfile());
                    mc.AddProfile(new ProducerDetailModelMapperProfile());
                    mc.AddProfile(new TypeOfLogicModelMapperProfile());
                    mc.AddProfile(new AccessPointListModelMapperProfile());
                    mc.AddProfile(new MachineNormModelMapperProfile());
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
        public void CreateMachine()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                
            }
        }
    }
}
