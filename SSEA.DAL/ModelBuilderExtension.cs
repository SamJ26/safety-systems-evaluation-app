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
            // TODO: modelBuilder.Entity<Architecture>().HasData();

            modelBuilder.Entity<Av>().HasData(
                new Av()
                {
                    DescriptionCZ = "Nemožné",
                    Value = 5,
                    IsValid = true,
                },
                new Av()
                {
                    DescriptionCZ = "Možné za určitých podmínek",
                    Value = 3,
                    IsValid = true,
                },
                new Av()
                {
                    DescriptionCZ = "Pradvěpodobné",
                    Value = 1,
                    IsValid = true,
                }
            );

            modelBuilder.Entity<Fr>().HasData(
                new Fr()
                {
                    FrequencyOfThreatCZ = "<= 1h",
                    Value = 5,
                    IsValid = true,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1h až <= 1 den",
                    Value = 5,
                    IsValid = true,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1 den až <= 2 týdny",
                    Value = 4,
                    IsValid = true,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 2 týdny až <= 1 rok",
                    Value = 3,
                    IsValid = true,
                },
                new Fr()
                {
                    FrequencyOfThreatCZ = "> 1 rok",
                    Value = 2,
                    IsValid = true,
                }
            );

            modelBuilder.Entity<Se>().HasData(
                new Se()
                {
                    DescriptionCZ = "Trvalé: smrt, ztráta oka nebo paže",
                    Value = 4,
                    IsValid = true,
                },
                new Se()
                {
                    DescriptionCZ = "Trvalé: zlomená končetina, ztráta prstu",
                    Value = 3,
                    IsValid = true,
                },
                new Se()
                {
                    DescriptionCZ = "Přechodné: vyžadující ošetření praktickým lékařem",
                    Value = 2,
                    IsValid = true,
                },
                new Se()
                {
                    DescriptionCZ = "Přechodné: vyžadující ošetření na první pomoci",
                    Value = 1,
                    IsValid = true,
                }
            );

            modelBuilder.Entity<Pr>().HasData(
                new Pr()
                {
                    DescriptionCZ = "Velmi vysoká",
                    Value = 5,
                    IsValid = true,
                },
                new Pr()
                {
                    DescriptionCZ = "Pravděpodobná",
                    Value = 4,
                    IsValid = true,
                },
                new Pr()
                {
                    DescriptionCZ = "Možná",
                    Value = 3,
                    IsValid = true,
                },
                new Pr()
                {
                    DescriptionCZ = "Výjimečná",
                    Value = 2,
                    IsValid = true,
                },
                new Pr()
                {
                    DescriptionCZ = "Zanedbatelná",
                    Value = 1,
                    IsValid = true,
                }
            );
        }
    }
}
