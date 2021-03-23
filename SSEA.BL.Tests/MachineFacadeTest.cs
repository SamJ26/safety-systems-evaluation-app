using AutoMapper;
using SSEA.BL.Facades;
using SSEA.BL.Models;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
using SSEA.DAL.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    mc.AddProfile(new ProducerModelMapperProfile());
                    mc.AddProfile(new TypeOfLogicModelMapperProfile());
                    mc.AddProfile(new PLModelMapperProfile());
                    mc.AddProfile(new PFHdModelMapperProfile());
                    mc.AddProfile(new ArchitectureModelMapperProfile());
                    mc.AddProfile(new CategoryModelMapperProfile());
                    mc.AddProfile(new MTTFdModelMapperProfile());
                    mc.AddProfile(new DCModelMapperProfile());
                    mc.AddProfile(new AccessPointListModelMapperProfile());
                    mc.AddProfile(new MachineNormModelMapperProfile());
                    mc.AddProfile(new NormModelMapperProfile());
                    mc.AddProfile(new StateModelMapperProfile());
                });
                mapper = mapperConfig.CreateMapper();
            }
            dbContextFactory = new DbContextInMemoryFactory(nameof(AppDbContext));
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }
    }
}
