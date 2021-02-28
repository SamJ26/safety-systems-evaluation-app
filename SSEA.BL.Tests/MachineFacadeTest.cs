using AutoMapper;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using SSEA.DAL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Repositories;
using SSEA.DAL.Tests;
using System;
using System.Collections.Generic;
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
        public async Task CreateMachine()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                MachineFacade facade = new MachineFacade(new Repository<Machine>(dbContext), mapper);
                var machine = new MachineDetailModel()
                {
                    Name = "Machine1",
                    Description = "Description",
                    Communication = false,
                    HMI = true,
                    EvaluationMethod = new EvaluationMethodModel()
                    {
                        Shortcut = "PL",
                    },
                    MachineType = new MachineTypeModel()
                    {
                        Name = "Some type",
                    },
                    Producer = new ProducerDetailModel()
                    {
                        Name = "Sipron",
                        CountryOfOrigin = "Slovakia",
                    },
                    TypeOfLogic = new TypeOfLogicModel()
                    {
                        Name = "CR30",
                    },
                };
                var id = await facade.CreateAsync(machine);
                Assert.True(id != 0);
                var existingMachine = await facade.GetByIdAsync(id);
                Assert.Equal(machine.Name, existingMachine.Name);
            }
        }

        [Fact]
        public async Task GetAllMachines()
        {
            using (dbContext = dbContextFactory.CreateDbContext())
            {
                MachineFacade facade = new MachineFacade(new Repository<Machine>(dbContext), mapper);
                var machine2 = new MachineDetailModel()
                {
                    Name = "Machine2",
                    Description = "Description",
                    Communication = false,
                    EvaluationMethod = new EvaluationMethodModel() { Shortcut = "PL" },
                    MachineType = new MachineTypeModel() { Name = "Some type" },
                    Producer = new ProducerDetailModel() { Name = "Sipron" },
                    TypeOfLogic = new TypeOfLogicModel() { Name = "CR30" },
                };
                var machine3 = new MachineDetailModel()
                {
                    Name = "Machine3",
                    Description = "Description",
                    Communication = false,
                    EvaluationMethod = new EvaluationMethodModel() { Shortcut = "SIL" },
                    MachineType = new MachineTypeModel() { Name = "Some type" },
                    Producer = new ProducerDetailModel() { Name = "Siemens" },
                    TypeOfLogic = new TypeOfLogicModel() { Name = "PLC" },
                };
                var id1 = await facade.CreateAsync(machine3);
                Assert.True(id1 != 0);
                var id2 = await facade.CreateAsync(machine2);
                Assert.True(id2 != 0);
                Assert.True(id1 != id2);
                var machines = await facade.GetAllAsync();
                Assert.True(machines.Count == 3);
            }
        }
    }
}
