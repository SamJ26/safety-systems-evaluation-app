using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSEA.DAL
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // TODO: validated data by competent person
            // TODO: add DateTimeCreated, IdCreated and IsValid properties

            #region Data for SIL methodics

            modelBuilder.Entity<Av>().HasData(
                new Av()
                {
                    Id = 1,
                    DescriptionCZ = "Nemožné",
                    Value = 5,
                },
                new Av()
                {
                    Id = 2,
                    DescriptionCZ = "Možné za určitých podmínek",
                    Value = 3,
                },
                new Av()
                {
                    Id = 3,
                    DescriptionCZ = "Pradvěpodobné",
                    Value = 1,
                }
            );

            modelBuilder.Entity<Fr>().HasData(
                new Fr()
                {
                    Id = 1,
                    FrequencyOfThreatCZ = "<= 1h",
                    Value = 5,
                },
                new Fr()
                {
                    Id = 2,
                    FrequencyOfThreatCZ = "> 1h až <= 1 den",
                    Value = 5,
                },
                new Fr()
                {
                    Id = 3,
                    FrequencyOfThreatCZ = "> 1 den až <= 2 týdny",
                    Value = 4,
                },
                new Fr()
                {
                    Id = 4,
                    FrequencyOfThreatCZ = "> 2 týdny až <= 1 rok",
                    Value = 3,
                },
                new Fr()
                {
                    Id = 5,
                    FrequencyOfThreatCZ = "> 1 rok",
                    Value = 2,
                }
            );

            modelBuilder.Entity<Se>().HasData(
                new Se()
                {
                    Id = 1,
                    DescriptionCZ = "Trvalé: smrt, ztráta oka nebo paže",
                    Value = 4,
                },
                new Se()
                {
                    Id = 2,
                    DescriptionCZ = "Trvalé: zlomená končetina, ztráta prstu",
                    Value = 3,
                },
                new Se()
                {
                    Id = 3,
                    DescriptionCZ = "Přechodné: vyžadující ošetření praktickým lékařem",
                    Value = 2,
                },
                new Se()
                {
                    Id = 4,
                    DescriptionCZ = "Přechodné: vyžadující ošetření na první pomoci",
                    Value = 1,
                }
            );

            modelBuilder.Entity<Pr>().HasData(
                new Pr()
                {
                    Id = 1,
                    DescriptionCZ = "Velmi vysoká",
                    Value = 5,
                },
                new Pr()
                {
                    Id = 2,
                    DescriptionCZ = "Pravděpodobná",
                    Value = 4,
                },
                new Pr()
                {
                    Id = 3,
                    DescriptionCZ = "Možná",
                    Value = 3,
                },
                new Pr()
                {
                    Id = 4,
                    DescriptionCZ = "Výjimečná",
                    Value = 2,
                },
                new Pr()
                {
                    Id = 5,
                    DescriptionCZ = "Zanedbatelná",
                    Value = 1,
                }
            );

            modelBuilder.Entity<CFF>().HasData(
                new CFF()
                {
                    Id = 1,
                    MinCCF = 0,
                    MaxCCF = 35,
                    Beta = 0.1,
                },
                new CFF()
                {
                    Id = 2,
                    MinCCF = 35,
                    MaxCCF = 65,
                    Beta = 0.05,
                },
                new CFF()
                {
                    Id = 3,
                    MinCCF = 65,
                    MaxCCF = 85,
                    Beta = 0.02,
                },
                new CFF()
                {
                    Id = 4,
                    MinCCF = 85,
                    MaxCCF = 100,
                    Beta = 0.01,
                }
            );

            modelBuilder.Entity<PFHd>().HasData(
                new PFHd()
                {
                    Id = 1,
                    ValueSIL = 3,
                    MinPFHd = 10E-8F,
                    MaxPFHd = 10E-7F,
                },
                new PFHd()
                {
                    Id = 2,
                    ValueSIL = 2,
                    MinPFHd = 10E-7F,
                    MaxPFHd = 10E-6F,
                },
                new PFHd()
                {
                    Id = 3,
                    ValueSIL = 1,
                    MinPFHd = 10E-6F,
                    MaxPFHd = 10E-5F,
                }
            );

            modelBuilder.Entity<SFF>().HasData(
                new SFF()
                {
                    Id = 1,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 2,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 3,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Současný zkrat mezi třemi kontakty přepínacího spínače",
                    Value = 10,
                }

                // TODO: supply all data from table in norm EN ISO 62061 

            );

            modelBuilder.Entity<Architecture>().HasData(
                new Architecture()
                {
                    Id = 1,
                    Label = "A",
                    Logic = true,
                    Diagnostic = false,
                    Channels = 1,
                    MinSFF = 60,
                    MaxSFF = 99,
                    HFT = 0,
                    MaxPFHdId = 1,
                },
                new Architecture()
                {
                    Id = 2,
                    Label = "B",
                    Logic = true,
                    Diagnostic = false,
                    Channels = 2,
                    MinSFF = 0,
                    MaxSFF = 99,
                    HFT = 1,
                    MaxPFHdId = 1,
                },
                new Architecture()
                {
                    Id = 3,
                    Label = "C",
                    Logic = true,
                    Diagnostic = true,
                    Channels = 1,
                    MinSFF = 60,
                    MaxSFF = 99,
                    HFT = 0,
                    MaxPFHdId = 1,
                },
                new Architecture()
                {
                    Id = 4,
                    Label = "D",
                    Logic = true,
                    Diagnostic = true,
                    Channels = 2,
                    MinSFF = 0,
                    MaxSFF = 99,
                    HFT = 1,
                    MaxPFHdId = 1,
                }
            );

            #endregion

            #region Data for PL methodics

            modelBuilder.Entity<S>().HasData(
                new S()
                {
                    Id = 1,
                    Value = "S1",
                    DescriptionCZ = "Lehké",
                },
                new S()
                {
                    Id = 2,
                    Value = "S2",
                    DescriptionCZ = "Závažné",
                }
            );

            modelBuilder.Entity<F>().HasData(
                new F()
                {
                    Id = 1,
                    Value = "F1",
                    DescriptionCZ = "Řídká až málo častá",
                },
                new F()
                {
                    Id = 2,
                    Value = "F2",
                    DescriptionCZ = "Častá až nepřetržitá",
                }
            );

            modelBuilder.Entity<P>().HasData(
                new P()
                {
                    Id = 1,
                    Value = "P1",
                    DescriptionCZ = "Možné za určitých podmínek",
                },
                new P()
                {
                    Id = 2,
                    Value = "P2",
                    DescriptionCZ = "Sotva možné",
                }
            );

            modelBuilder.Entity<PerformanceLevel>().HasData(
                new PerformanceLevel()
                {
                    Id = 1,
                    Label = "a",
                },
                new PerformanceLevel()
                {
                    Id = 2,
                    Label = "b",
                },
                new PerformanceLevel()
                {
                    Id = 3,
                    Label = "c",
                },
                new PerformanceLevel()
                {
                    Id = 4,
                    Label = "d",
                },
                new PerformanceLevel()
                {
                    Id = 5,
                    Label = "e",
                }
            );

            modelBuilder.Entity<MTTFd>().HasData(
                new MTTFd()
                {
                    Id = 1,
                    ValueCZ = "Krátká",
                    Min = 3,
                    Max = 10,
                },
                new MTTFd()
                {
                    Id = 2,
                    ValueCZ = "Střední",
                    Min = 10,
                    Max = 30,
                },
                new MTTFd()
                {
                    Id = 3,
                    ValueCZ = "Dlouhá",
                    Min = 30,
                    Max = 100,
                }
            );

            // TODO: add Category seeds

            #endregion

            #region Data for common entities

            modelBuilder.Entity<TypeOfSubsystem>().HasData(
                new TypeOfSubsystem()
                {
                    Id = 1,
                    NameCZ = "Vstupní",
                },
                new TypeOfSubsystem()
                {
                    Id = 2,
                    NameCZ = "Výstupní",
                },
                new TypeOfSubsystem()
                {
                    Id = 3,
                    NameCZ = "Logický",
                },
                new TypeOfSubsystem()
                {
                    Id = 4,
                    NameCZ = "Komunikační",
                }
            );

            modelBuilder.Entity<MachineType>().HasData(
                new MachineType()
                {
                    Id = 1,
                    NameCZ = "Jednoúčelový stroj",
                    DescriptionCZ = "Nějaký popis",
                },
                new MachineType()
                {
                    Id = 2,
                    NameCZ = "Víceúčelový stroj",
                    DescriptionCZ = "Nějaký popis",
                },
                new MachineType()
                {
                    Id = 3,
                    NameCZ = "Montážní linka",
                    DescriptionCZ = "Nějaký popis",
                }

                // TODO: supply all data

            );

            #endregion

        }
    }
}
