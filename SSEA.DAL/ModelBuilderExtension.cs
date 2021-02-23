using Microsoft.EntityFrameworkCore;
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
            #region Data for SIL methodics

            // TODO: modelBuilder.Entity<Architecture>().HasData()

            modelBuilder.Entity<Av>().HasData(
                new Av()
                {
                    DescriptionCZ = "Nemožné",
                    Value = 5,
                },
                new Av()
                {
                    DescriptionCZ = "Možné za určitých podmínek",
                    Value = 3,
                },
                new Av()
                {
                    DescriptionCZ = "Pradvěpodobné",
                    Value = 1,
                }
            );

            modelBuilder.Entity<Fr>().HasData(
                new Fr()
                {
                    FrequencyOfThreatCZ = "<= 1h",
                    Value = 5,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1h až <= 1 den",
                    Value = 5,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1 den až <= 2 týdny",
                    Value = 4,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 2 týdny až <= 1 rok",
                    Value = 3,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1 rok",
                    Value = 2,
                }
            );

            modelBuilder.Entity<Se>().HasData(
                new Se()
                {
                    DescriptionCZ = "Trvalé: smrt, ztráta oka nebo paže",
                    Value = 4,
                },
                new Se()
                {
                    DescriptionCZ = "Trvalé: zlomená končetina, ztráta prstu",
                    Value = 3,
                },
                new Se()
                {
                    DescriptionCZ = "Přechodné: vyžadující ošetření praktickým lékařem",
                    Value = 2,
                },
                new Se()
                {
                    DescriptionCZ = "Přechodné: vyžadující ošetření na první pomoci",
                    Value = 1,
                }
            );

            modelBuilder.Entity<Pr>().HasData(
                new Pr()
                {
                    DescriptionCZ = "Velmi vysoká",
                    Value = 5,
                },
                new Pr()
                {
                    DescriptionCZ = "Pravděpodobná",
                    Value = 4,
                },
                new Pr()
                {
                    DescriptionCZ = "Možná",
                    Value = 3,
                },
                new Pr()
                {
                    DescriptionCZ = "Výjimečná",
                    Value = 2,
                },
                new Pr()
                {
                    DescriptionCZ = "Zanedbatelná",
                    Value = 1,
                }
            );

            modelBuilder.Entity<CFF>().HasData(
                new CFF()
                {
                    MinCCF = 0,
                    MaxCCF = 35,
                    Beta = 0.1,
                },
                new CFF()
                {
                    MinCCF = 35,
                    MaxCCF = 65,
                    Beta = 0.05,
                },
                new CFF()
                {
                    MinCCF = 65,
                    MaxCCF = 85,
                    Beta = 0.02,
                },
                new CFF()
                {
                    MinCCF = 85,
                    MaxCCF = 100,
                    Beta = 0.01,
                }
            );

            modelBuilder.Entity<PFHd>().HasData(
                new PFHd()
                {
                    ValueSIL = 3,
                    MinPFHd = 10E-8F,
                    MaxPFHd = 10E-7F,
                },
                new PFHd()
                {
                    ValueSIL = 2,
                    MinPFHd = 10E-7F,
                    MaxPFHd = 10E-6F,
                },
                new PFHd()
                {
                    ValueSIL = 1,
                    MinPFHd = 10E-6F,
                    MaxPFHd = 10E-5F,
                }
            );

            modelBuilder.Entity<SFF>().HasData(
                new SFF()
                {
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 10,
                },
                new SFF()
                {
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Současný zkrat mezi třemi kontakty přepínacího spínače",
                    Value = 10,
                }

                // TODO: supply all data from table in norm EN ISO 62061 

            );

            #endregion

        }
    }
}
