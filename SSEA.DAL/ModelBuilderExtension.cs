using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.Auth;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;

namespace SSEA.DAL
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // TODO: validate data by competent person

            #region Data for SIL methodics

            modelBuilder.Entity<Av>().HasData(
                new Av()
                {
                    Id = 1,
                    DescriptionCZ = "Nemožné",
                    DescriptionEN = "Impossible",
                    Value = 5,
                },
                new Av()
                {
                    Id = 2,
                    DescriptionCZ = "Možné za určitých podmínek",
                    DescriptionEN = "Possible under certain conditions",
                    Value = 3,
                },
                new Av()
                {
                    Id = 3,
                    DescriptionCZ = "Pravděpodobné",
                    DescriptionEN = "Probably",
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
                    DescriptionEN = "Permanent: death, loss of eye or arm",
                    Value = 4,
                },
                new Se()
                {
                    Id = 2,
                    DescriptionCZ = "Trvalé: zlomená končetina, ztráta prstu",
                    DescriptionEN = "Permanent: broken limb, loss of finger",
                    Value = 3,
                },
                new Se()
                {
                    Id = 3,
                    DescriptionCZ = "Přechodné: vyžadující ošetření praktickým lékařem",
                    DescriptionEN = "Transient: requiring GP treatment",
                    Value = 2,
                },
                new Se()
                {
                    Id = 4,
                    DescriptionCZ = "Přechodné: vyžadující ošetření na první pomoci",
                    DescriptionEN = "Transient: requiring first aid treatment",
                    Value = 1,
                }
            );

            modelBuilder.Entity<Pr>().HasData(
                new Pr()
                {
                    Id = 1,
                    DescriptionCZ = "Velmi vysoká",
                    DescriptionEN = "Very high",
                    Value = 5,
                },
                new Pr()
                {
                    Id = 2,
                    DescriptionCZ = "Pravděpodobná",
                    DescriptionEN = "Probable",
                    Value = 4,
                },
                new Pr()
                {
                    Id = 3,
                    DescriptionCZ = "Možná",
                    DescriptionEN = "Possible",
                    Value = 3,
                },
                new Pr()
                {
                    Id = 4,
                    DescriptionCZ = "Výjimečná",
                    DescriptionEN = "Extraordinary",
                    Value = 2,
                },
                new Pr()
                {
                    Id = 5,
                    DescriptionCZ = "Zanedbatelná",
                    DescriptionEN = "Negligible",
                    Value = 1,
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

            // TODO: translate to english
            modelBuilder.Entity<SFF>().HasData(
                new SFF()
                {
                    Id = 1,
                    ComponentNameCZ = "Spínač s nuceným vypínaním",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 20,
                },
                new SFF()
                {
                    Id = 2,
                    ComponentNameCZ = "Spínač s nuceným vypínaním",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 80,
                },
                new SFF()
                {
                    Id = 3,
                    ComponentNameCZ = "Elektromechanický konocový spínač, polohový spínač, koncový spínač, ručně ovladaný spínač atd.",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 50,
                },
                new SFF()
                {
                    Id = 4,
                    ComponentNameCZ = "Elektromechanický konocový spínač, polohový spínač, koncový spínač, ručně ovladaný spínač atd.",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 50,
                },
                new SFF()
                {
                    Id = 5,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Všechny kontakty zůstavají v zapnuté poloze, je-li cívka bez napětí",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 6,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Všechny kontakty zůstavají ve vypnuté poloze, je-li cívka pod napětím",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 7,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 8,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 9,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Současný zkrat mezi třemi kontakty přepínacího spínače",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 10,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Současné zapnutí zapínacího a vypínacího kontaktu",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 11,
                    ComponentNameCZ = "Relé",
                    FailureModeCZ = "Zkrat medzi dvěma páry kontaktů a/nebo mezi kontakty a svorku cívky",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 12,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Všechny kontakty zůstavají v zapnuté poloze, je-li cívka bez napětí",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 13,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Všechny kontakty zůstavají ve vypnuté poloze, je-li cívka pod napětí",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 14,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 15,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Kontakty nelze sepnou",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 16,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Současný zkrat medzi třemi kontakty přepínacího spínače",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 17,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Současné zapnutí zapínacího a vypínacího kontaktu",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 18,
                    ComponentNameCZ = "Jistič, proudový chránič",
                    FailureModeCZ = "Zkrat medzi dvěmi páry kontaktů a/nebo medzi kontakty a svorkou civky",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 19,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Všechny kontakty zůstávají v zapnuté poloze, je-li cívka bez napětí",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 20,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Všeschny Kontakty zůstávajé ve vypnuté poloze, je-li cívka pod napětím",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 21,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 22,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 23,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Současný zkrat medzi třemi kontakty přepínacího spínače",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 24,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Současné zapnutí zapínacího a vypínacího kontaktu",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 25,
                    ComponentNameCZ = "Stykač",
                    FailureModeCZ = "Zkrat medzi dvěma páry kontaktů a/nebo medzi kontakty a svorku cívky",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 26,
                    ComponentNameCZ = "Poistka",         
                    FailureModeCZ = "Nedojde k přtavení (zkrat)",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 27,
                    ComponentNameCZ = "Poistka",
                    FailureModeCZ = "Přerušený obvod",
                    Value = 90,
                },
                new SFF()
                {
                    Id = 28,
                    ComponentNameCZ = "Bezdotykové spínače",
                    FailureModeCZ = "Trvalé nízke rezistance na výstupu",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 29,
                    ComponentNameCZ = "Bezdotykové spínače",
                    FailureModeCZ = "Trvalé vysoká rezistance na výstupu",
                    Value = 25,
                },
                new SFF()
                {
                    Id = 30,
                    ComponentNameCZ = "Bezdotykové spínače",
                    FailureModeCZ = "Přerušní napájaní",
                    Value = 30,
                },
                new SFF()
                {
                    Id = 31,
                    ComponentNameCZ = "Bezdotykové spínače",
                    FailureModeCZ = "Selhíni spínače vlivem mechanické poruchy",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 32,
                    ComponentNameCZ = "Bezdotykové spínače",
                    FailureModeCZ = "Současný zkrat mezi třemi kontakty přepínacího spínače",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 33,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 30,
                },
                new SFF()
                {
                    Id = 34,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 35,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Zkrat medzi sousedními kontakty",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 36,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Zkrat medzi třemi svorkami přepínacích kontaktů",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 37,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Vada čidla",
                    Value = 20,
                },
                new SFF()

                {
                    Id = 38,
                    ComponentNameCZ = "Teplotní spínač",
                    FailureModeCZ = "Zmena měřích nebo výstupních charakteristik",
                    Value = 20,
                },
                new SFF()
                {
                    Id = 39,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Kontakty nelze rozepnout",
                    Value = 30,
                },
                new SFF()
                {
                    Id = 40,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Kontakty nelze sepnout",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 41,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Zkrat mezi sousedními kontakty",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 42,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Současný zkat medzi třemi svorkami přepínacích kontaktů",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 43,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Vada čidla",
                    Value = 20,
                },
                new SFF()
                {
                    Id = 44,
                    ComponentNameCZ = "Tlakový spínač",
                    FailureModeCZ = "Změna meřícich nebo výstupních charakteristik",
                    Value = 20,
                },
                new SFF()
                {
                    Id = 45,
                    ComponentNameCZ = "Solenoidový ventil",
                    FailureModeCZ = "Nelze nabudit",
                    Value = 5,
                },
                new SFF()
                {
                    Id = 46,
                    ComponentNameCZ = "Solenoidový ventil",
                    FailureModeCZ = "Nelze odbudit",
                    Value = 15,
                },
                new SFF()
                {
                    Id = 47,
                    ComponentNameCZ = "Solenoidový ventil",
                    FailureModeCZ = "Změna doby spínaní",
                    Value = 5,
                },
                new SFF()
                {
                    Id = 48,
                    ComponentNameCZ = "Solenoidový ventil",
                    FailureModeCZ = "Netěsnost",
                    Value = 65,
                },
                new SFF()
                {
                    Id = 49,
                    ComponentNameCZ = "Solenoidový ventil",
                    FailureModeCZ = "Další poruchové režimy (viz poznámka 4)",
                    Value = 10
                },
                new SFF()
                {
                    Id = 50,
                    ComponentNameCZ = "Vidlice a zásuvky, konektory",
                    FailureModeCZ = "Zkrat medzi libovolnými dvěma sousedními spoji (koliky)",
                    Value = 10,
                },
                new SFF()

                {
                    Id = 51,
                    ComponentNameCZ = "Vidlice a zásuvky, konektory",
                    FailureModeCZ = "Zkrat libovolného vodiče s neživou částí",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 52,
                    ComponentNameCZ = "Vidlice a zásuvky, konektory",
                    FailureModeCZ = "Rozpojený obvod libovolného spoje (koliku) konektoru",
                    Value = 80,
                },
                new SFF()
                {
                    Id = 53,
                    ComponentNameCZ = "Svorkovnice",
                    FailureModeCZ = "Zkrat medzi sousedními svorkami",
                    Value = 10,
                },
                new SFF()
                {
                    Id = 54,
                    ComponentNameCZ = "Svorkovnice",
                    FailureModeCZ = "Rozpojený obvod svorek",
                    Value = 90,
                }
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
                    CompareValue = 1,
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
                    CompareValue = 2,
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
                    CompareValue = 3,
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
                    CompareValue = 4,
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
                    DescriptionEN = "Small",
                },
                new S()
                {
                    Id = 2,
                    Value = "S2",
                    DescriptionCZ = "Závažné",
                    DescriptionEN = "Serious",
                }
            );

            modelBuilder.Entity<F>().HasData(
                new F()
                {
                    Id = 1,
                    Value = "F1",
                    DescriptionCZ = "Řídká až málo častá",
                    DescriptionEN = "Sparse to infrequent",
                },
                new F()
                {
                    Id = 2,
                    Value = "F2",
                    DescriptionCZ = "Častá až nepřetržitá",
                    DescriptionEN = "Frequent to continuous",
                }
            );

            modelBuilder.Entity<P>().HasData(
                new P()
                {
                    Id = 1,
                    Value = "P1",
                    DescriptionCZ = "Možné za určitých podmínek",
                    DescriptionEN = "Possible under certain conditions",
                },
                new P()
                {
                    Id = 2,
                    Value = "P2",
                    DescriptionCZ = "Sotva možné",
                    DescriptionEN = "Hardly possible",
                }
            );

            modelBuilder.Entity<PerformanceLevel>().HasData(
                new PerformanceLevel()
                {
                    Id = 1,
                    Label = "a",
                    CompareValue = 1,
                },
                new PerformanceLevel()
                {
                    Id = 2,
                    Label = "b",
                    CompareValue = 2,
                },
                new PerformanceLevel()
                {
                    Id = 3,
                    Label = "c",
                    CompareValue = 3,
                },
                new PerformanceLevel()
                {
                    Id = 4,
                    Label = "d",
                    CompareValue = 4,
                },
                new PerformanceLevel()
                {
                    Id = 5,
                    Label = "e",
                    CompareValue = 5,
                }
            );

            modelBuilder.Entity<MTTFd>().HasData(
                new MTTFd()
                {
                    Id = 1,
                    ValueCZ = "Krátká",
                    ValueEN = "Short",
                    Min = 3,
                    Max = 10,
                    CompareValue = 1,
                },
                new MTTFd()
                {
                    Id = 2,
                    ValueCZ = "Střední",
                    ValueEN = "Medium",
                    Min = 10,
                    Max = 30,
                    CompareValue = 2,
                },
                new MTTFd()
                {
                    Id = 3,
                    ValueCZ = "Dlouhá",
                    ValueEN = "Long",
                    Min = 30,
                    Max = 100,
                    CompareValue = 3,
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Label = "B",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = false,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 2,
                    MinDCId = 1,
                    MaxDCId = 1,
                    CompareValue = 1,
                },
                new Category()
                {
                    Id = 2,
                    Label = "1",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = false,
                    MinMTTFdId = 3,
                    MaxMTTFdId = 3,
                    MinDCId = 1,
                    MaxDCId = 1,
                    CompareValue = 2,
                },
                new Category()
                {
                    Id = 3,
                    Label = "2",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = true,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 3,
                    MinDCId = 2,
                    MaxDCId = 3,
                    CompareValue = 3,
                },
                new Category()
                {
                    Id = 4,
                    Label = "3",
                    Logic = true,
                    Channels = 2,
                    RelevantCCF = true,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 3,
                    MinDCId = 2,
                    MaxDCId = 3,
                    CompareValue = 4,
                },
                new Category()
                {
                    Id = 5,
                    Label = "4",
                    Logic = true,
                    Channels = 2,
                    RelevantCCF = true,
                    MinMTTFdId = 3,
                    MaxMTTFdId = 3,
                    MinDCId = 4,
                    MaxDCId = 4,
                    CompareValue = 5,
                }
            );

            #endregion

            #region Data for common entities

            modelBuilder.Entity<TypeOfSubsystem>().HasData(
                new TypeOfSubsystem()
                {
                    Id = 1,
                    NameCZ = "Vstupní",
                    NameEN = "Input",
                },
                new TypeOfSubsystem()
                {
                    Id = 2,
                    NameCZ = "Výstupní",
                    NameEN = "Output",
                },
                new TypeOfSubsystem()
                {
                    Id = 3,
                    NameCZ = "Logický",
                    NameEN = "Logical",
                },
                new TypeOfSubsystem()
                {
                    Id = 4,
                    NameCZ = "Komunikace vstup-logika",
                    NameEN = "Input-logic communication",
                },
                new TypeOfSubsystem()
                {
                    Id = 5,
                    NameCZ = "Komunikace výstup-logika",
                    NameEN = "Output-logic communication",
                }
            );

            modelBuilder.Entity<OperationPrinciple>().HasData(
                new OperationPrinciple()
                {
                    Id = 1,
                    NameCZ = "Mechanický",
                    NameEN = "Mechanical",
                },
                new OperationPrinciple()
                {
                    Id = 2,
                    NameCZ = "Elektrický",
                    NameEN = "Electrical",
                },
                new OperationPrinciple()
                {
                    Id = 3,
                    NameCZ = "Pneumatický",
                    NameEN = "Pneumatic",
                },
                new OperationPrinciple()
                {
                    Id = 4,
                    NameCZ = "Elektromechanický",
                    NameEN = "Electromechanical",
                },
                new OperationPrinciple()
                {
                    Id = 5,
                    NameCZ = "Hydraulický",
                    NameEN = "Hydraulic",
                }
            );

            modelBuilder.Entity<MachineType>().HasData(
                new MachineType()
                {
                    Id = 1,
                    NameCZ = "Jednoúčelový stroj",
                    NameEN = "Single-purpose machine",
                },
                new MachineType()
                {
                    Id = 2,
                    NameCZ = "Víceúčelový stroj",
                    NameEN = "Multi-purpose machine",
                },
                new MachineType()
                {
                    Id = 3,
                    NameCZ = "Montážní linka",
                    NameEN = "Assembly line",
                }
            );

            // TODO: translate to english
            modelBuilder.Entity<Norm>().HasData(
                new Norm()
                {
                    Id = 1,
                    Label = "ISO 11200",
                    NameCZ = "Rušení - Určovaní emisních hladín akustického tlaku na stanovišti obsluhy",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 2,
                    Label = "ISO 3741",
                    NameCZ = "Rušení - Určení hladín akustického výkonu a hladin akusticko energie zdroju hluku",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 3,
                    Label = "ISO 9614",
                    NameCZ = "Rušení - Určovaní hladin akustického výkonu zdroju hluku pomocí akustické intenzity",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 4,
                    Label = "ISO 11546",
                    NameCZ = "Rušení - Určovaní zvkové izolace krytů",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 5,
                    Label = "ISO 11957",
                    NameCZ = "Rušení - Určení zvukové izolace kabin",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 6,
                    Label = "ISO 4871",
                    NameCZ = "Rušení - Deklarování a ověřování hodnot emise hluku",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()

                {
                    Id = 7,
                    Label = "ISO 29042",
                    NameCZ = "Obsažené látky - Hodnocení emisí nebezpečných látek přenášených vzduchem",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 8,
                    Label = "ISO 14123-1",
                    NameCZ = "Obsažené látky - Snižování ohroženými látkami emitovanými stojním zařízením",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 9,
                    Label = "ISO 14159",
                    NameCZ = "Obsažené látky - Hygienické požadavky",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 10,
                    Label = "ISO 13732-1",
                    NameCZ = "Tepelná rizika - Metody posuzování odezvy člověka na kontakt s horkými povrchy",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 11,
                    Label = "ISO 19363",
                    NameCZ = "Požarní riziká - Požarní prevence a požarní ochrana",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 12,
                    Label = "IEC 60204-1",
                    NameCZ = "Elektrická rizika - Ochrana proti zásahu elektrickým proudem",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 13,
                    Label = "ISO 2631",
                    NameCZ = "Vibrace a rázy - Expozice celkovým vibracím",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 14,
                    Label = "ISO 13753",
                    NameCZ = "Vibrace a rázy - Vibrace ruky a paže",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 15,
                    Label = "ISO 20643",
                    NameCZ = "Vibrace a rázy - Ruční a rukou vedená strojní zařizení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 16,
                    Label = "ISO 15534",
                    NameCZ = "Ergonomie - Přístupové otvory",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 17,
                    Label = "ISO 14738",
                    NameCZ = "Ergonomie - Antropometrické požadavky na uspořádané pracovního místa u strojního zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 18,
                    Label = "ISO 15536-1",
                    NameCZ = "Ergonomie - Počítačové modely lidského těla a tělesné šablony",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 19,
                    Label = "ISO 11145",
                    NameCZ = "Radiační rizika - Lasary a laserová zařízení - obecné požadavky",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 20,
                    Label = "ISO 13854",
                    NameCZ = "Rozměry a vzdálenosti - Nejemenší mezery k zamezení stlačení částí lidského těla",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 21,
                    Label = "ISO 13855",
                    NameCZ = "Rozměry a vzdálenosti - Minimální vzdálenosti",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 22,
                    Label = "ISO 13857",
                    NameCZ = "Rozměry a vzdálenosti - Bezepečné vzdálenosti",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 23,
                    Label = "ISO 14122",
                    NameCZ = "Rozměry a vzdálenosti - Trvalé prostředky přístupu ke strojním zařízením",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 24,
                    Label = "ISO 3864-1",
                    NameCZ = "Alarmy a varování - Zásady navrhování bezpečnostních značek a bezpečnostního značení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 25,
                    Label = "ISO 7010",
                    NameCZ = "Alarmy a varování - Registrované bezpečnostní značky",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 26,
                    Label = "ISO 7731",
                    NameCZ = "Alarmy a varování - Sluchové výstražní signály",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 27,
                    Label = "IEC 61310-1",
                    NameCZ = "Alarmy a varování - Požadavky na vizuální, akustické a taktilná signály",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 28,
                    Label = "IEC 60204-1",
                    NameCZ = "Napájecí zdroj - Elektrická zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 29,
                    Label = "ISO 4414",
                    NameCZ = "Napájecí zdroj - Pneumatická zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 30,
                    Label = "ISO 4413",
                    NameCZ = "Napájecí zdroj - Hydraulická zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 31,
                    Label = "ISO 14118",
                    NameCZ = "Řidicí systémy - Zamezení neočekávanému spuštění",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 32,
                    Label = "ISO 13849-1",
                    NameCZ = "Řidicí systémy - Konstrukcde bezpečnostních částí ovládacího systémů",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 33,
                    Label = "ISO 13849-2",
                    NameCZ = "Řidicí systémy - Ověřovani bezpečnostních častí ovládacích systémů",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 34,
                    Label = "ISO 13850",
                    NameCZ = "Řidicí systémy - Funkce nouzového zastavení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 35,
                    Label = "ISO 14120",
                    NameCZ = "Bezpečnostní zařízení - Ochranné kryty",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 36,
                    Label = "ISO 14119",
                    NameCZ = "Bezpečnostní zařízení - Blokovací zařízení spojená s ochrannými kryty",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 37,
                    Label = "ISO 13851",
                    NameCZ = "Bezpečnostní zařízení -Dvouruční ovládací zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 38,
                    Label = "IEC 61496",
                    NameCZ = "Bezpečnostní zařízení - Elektrická snímací ochranná zařízení",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 39,
                    Label = "ISO 13856",
                    NameCZ = "Bezpečnostní zařízení - Ochranná zařízení citlivá na tlak",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                },
                new Norm()
                {
                    Id = 40,
                    Label = "ISO 11161",
                    NameCZ = "Bezpečnostní zařízení - Integrované výrobní systémy",
                    CatalogNumber = "unknown",
                    NormCategory = "B",
                }
            );

            modelBuilder.Entity<EvaluationMethod>().HasData(
                new EvaluationMethod()
                {
                    Id = 1,
                    NameCZ = "Úroveň vlastností",
                    NameEN = "Performance Level",
                    Shortcut = "PL",
                },
                new EvaluationMethod()
                {
                    Id = 2,
                    NameCZ = "Úroveň integrity bezpečnosti",
                    NameEN = "Safety Integrity Level",
                    Shortcut = "SIL",
                }
            );

            modelBuilder.Entity<DC>().HasData(
                new DC()
                {
                    Id = 1,
                    ValueCZ = "Žádné",
                    ValueEN = "None",
                    Min = 0,
                    Max = 60,
                    CompareValue = 1,
                },
                new DC()
                {
                    Id = 2,
                    ValueCZ = "Nízké",
                    ValueEN = "Low",
                    Min = 60,
                    Max = 90,
                    CompareValue = 2,
                },
                new DC()
                {
                    Id = 3,
                    ValueCZ = "Střední",
                    ValueEN = "Medium",
                    Min = 90,
                    Max = 99,
                    CompareValue = 3,
                },
                new DC()
                {
                    Id = 4,
                    ValueCZ = "Vysoké",
                    ValueEN = "High",
                    Min = 99,
                    Max = 100,
                    CompareValue = 4,
                }
            );

            // TODO: translate to english
            modelBuilder.Entity<CCF>().HasData(
                new CCF()
                {
                    Id = 1,
                    DescriptionCZ = "Fyzické oddělení medzi jednotlivými dráhami signálu",
                    TypeCZ = "Oddělení/segregace",
                    Points = 15,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 2,
                    DescriptionCZ = "Jsou použity ruzné technologie/konstrukce nebo fyzikální principy",
                    TypeCZ = "Diverzita",
                    Points = 20,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 3,
                    DescriptionCZ = "Ochrana proti přepětí, přetlaku, nadproudu, atd.",
                    TypeCZ = "Konstrukce/použití/zkušenosti",
                    Points = 15,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 4,
                    DescriptionCZ = "Jsou použity osvědčené součásti",
                    TypeCZ = "Konstrukce/použití/zkušenosti",
                    Points = 5,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 5,
                    DescriptionCZ = "Jsou k vyloučení poruch se společnou příčinou v konstrukci uvažovány výsledky režimu poruchy a analýza účinku?",
                    TypeCZ = "Posouzení/analýza",
                    Points = 5,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 6,
                    DescriptionCZ = "Byli konstruktéři/údržbáři zacvičení k pochopení příčin a následkú poruch se společnou příčinou ?",
                    TypeCZ = "Zpusobilost/zácvik",
                    Points = 5,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 7,
                    DescriptionCZ = "Zamezení kontaminace a elektromagnetická kompatibilita (EMC) proti CCF podle příslušných norem",
                    TypeCZ = "Prostředí",
                    Points = 25,
                    ForPL = true,
                },
                new CCF()
                {
                    Id = 8,
                    DescriptionCZ = "Byly uvažováni požadavky na odolnost proti všem relevantním vlivum prostředí, např. teplota, vibrace, vlhkost ?",
                    TypeCZ = "Prostředí",
                    Points = 10,
                    ForPL = true,
                }
            );

            modelBuilder.Entity<TypeOfFunction>().HasData(
                new TypeOfFunction()
                {
                    Id = 1,
                    NameCZ = "Funkce bezpečného zastavení iniciována bezpečnostním zařízením",
                    NameEN = "Safe stop function initiated by the safety device",
                },
                new TypeOfFunction()
                {
                    Id = 2,
                    NameCZ = "Funkce ručního opětného nastavení",
                    NameEN = "Manual reset function",
                },
                new TypeOfFunction()
                {
                    Id = 3,
                    NameCZ = "Funkce místního ovládaní",
                    NameEN = "Local control function",
                },
                new TypeOfFunction()
                {
                    Id = 4,
                    NameCZ = "Funkce spuštení/opětovného spuštení",
                    NameEN = "Start / restart function",
                },
                new TypeOfFunction()
                {
                    Id = 5,
                    NameCZ = "Funkce vyřazení",
                    NameEN = "Exclusion function",
                },
                new TypeOfFunction()
                {
                    Id = 6,
                    NameCZ = "Funkce tipování",
                    NameEN = "Tipping function",
                },
                new TypeOfFunction()
                {
                    Id = 7,
                    NameCZ = "Funkce povelového zařízení",
                    NameEN = "Command device functions",
                },
                new TypeOfFunction()
                {
                    Id = 8,
                    NameCZ = "Funkce zamezení neočekávaného spuštění",
                    NameEN = "Unexpected startup prevention function",
                },
                new TypeOfFunction()
                {
                    Id = 9,
                    NameCZ = "Únik a uvolnění zachycených osob",
                    NameEN = "Escape and release of captured persons",
                },
                new TypeOfFunction()
                {
                    Id = 10,
                    NameCZ = "Funkce odpojení a uvolnění energie",
                    NameEN = "Power disconnection and release function",
                },
                new TypeOfFunction()
                {
                    Id = 11,
                    NameCZ = "Režimy ovládání a volba režimu",
                    NameEN = "Control modes and mode selection",
                },
                new TypeOfFunction()
                {
                    Id = 12,
                    NameCZ = "Vzájemné púsobení rúzných bezpečnostních částí ovládacího systému",
                    NameEN = "Interaction of different safety parts of the control system",
                },
                new TypeOfFunction()
                {
                    Id = 13,
                    NameCZ = "Monitorování parametrizace hodnot bezpečnostního vstupu",
                    NameEN = "Monitoring the parameterization of safety input values",
                },
                new TypeOfFunction()
                {
                    Id = 14,
                    NameCZ = "Funkce nouzového zastavení",
                    NameEN = "Emergency stop function",
                }
            );

            modelBuilder.Entity<TypeOfLogic>().HasData(
                new TypeOfLogic()
                {
                    Id = 1,
                    NameCZ = "Relé",
                    NameEN = "Relay",
                    SI = 4,
                    SO = 4,
                    Communication = false,
                    AccessPointsMaxCount = 2,
                    EthernetAdressesMaxCount = 0,
                    MaxPLId = 5,
                    MaxCategoryId = 5,
                    MaxSILId = 1,
                    MaxArchitectureId = 4,
                    SubsystemId = 1,
                },
                new TypeOfLogic()
                {
                    Id = 2,
                    NameCZ = "CR30",
                    NameEN = "CR30",
                    SI = 12,
                    SO = 10,
                    Communication = false,
                    AccessPointsMaxCount = 5,
                    EthernetAdressesMaxCount = 0,
                    MaxPLId = 5,
                    MaxCategoryId = 5,
                    MaxSILId = 1,
                    MaxArchitectureId = 4,
                    SubsystemId = 2,
                },
                new TypeOfLogic()
                {
                    Id = 3,
                    NameCZ = "GMX",
                    NameEN = "GMX",
                    SI = 6144,
                    SO = 6144,
                    Communication = true,
                    AccessPointsMaxCount = null,
                    EthernetAdressesMaxCount = 48,
                    MaxPLId = 5,
                    MaxCategoryId = 5,
                    MaxSILId = 1,
                    MaxArchitectureId = 4,
                    SubsystemId = 3,
                },
                new TypeOfLogic()
                {
                    Id = 4,
                    NameCZ = "GLX",
                    NameEN = "GLX",
                    SI = 65536,
                    SO = 65536,
                    Communication = true,
                    AccessPointsMaxCount = null,
                    EthernetAdressesMaxCount = 256,
                    MaxPLId = 5,
                    MaxCategoryId = 5,
                    MaxSILId = 1,
                    MaxArchitectureId = 4,
                    SubsystemId = 4,
                }
            );

            modelBuilder.Entity<Producer>().HasData(
                new Producer()
                {
                    Id = 1,
                    Name = "Siemens",
                    CountryOfOrigin = "Germany",
                },
                new Producer()
                {
                    Id = 2,
                    Name = "Sipron",
                    CountryOfOrigin = "Slovakia",
                },
                new Producer()
                {
                    Id = 3,
                    Name = "Allen Bradley",
                    CountryOfOrigin = "USA",
                }
            );

            #endregion

            #region Data for main entities

            modelBuilder.Entity<Subsystem>().HasData(
                new Subsystem()
                {
                    Id = 1,
                    Description = "Relay",
                    TypeOfSubsystemId = 3,
                    OperationPrincipleId = 4,
                    ValidCCF = true,
                    CategoryId = 5,
                    ResultantMTTFdId = 3,
                    ResultantDCId = 4,
                    ResultantPLId = 5,
                    ArchitectureId = 4,
                    ResultantPFHdId = 1,
                    CalculatedPFHd = 0.00000001,
                    DateTimeCreated = System.DateTime.Now,
                    CurrentStateId = 16,
                },
                new Subsystem()
                {
                    Id = 2,
                    Description = "CR30",
                    TypeOfSubsystemId = 3,
                    OperationPrincipleId = 2,
                    ValidCCF = true,
                    CategoryId = 5,
                    ResultantMTTFdId = 3,
                    ResultantDCId = 4,
                    ResultantPLId = 5,
                    ArchitectureId = 4,
                    ResultantPFHdId = 1,
                    CalculatedPFHd = 0.00000001,
                    DateTimeCreated = System.DateTime.Now,
                    CurrentStateId = 16,
                },
                new Subsystem()
                {
                    Id = 3,
                    Description = "GMX",
                    TypeOfSubsystemId = 3,
                    OperationPrincipleId = 2,
                    ValidCCF = true,
                    CategoryId = 5,
                    ResultantMTTFdId = 3,
                    ResultantDCId = 4,
                    ResultantPLId = 5,
                    ArchitectureId = 4,
                    ResultantPFHdId = 1,
                    CalculatedPFHd = 0.00000001,
                    DateTimeCreated = System.DateTime.Now,
                    CurrentStateId = 16,
                },
                new Subsystem()
                {
                    Id = 4,
                    Description = "GLX",
                    TypeOfSubsystemId = 3,
                    OperationPrincipleId = 2,
                    ValidCCF = true,
                    CategoryId = 5,
                    ResultantMTTFdId = 3,
                    ResultantDCId = 4,
                    ResultantPLId = 5,
                    ArchitectureId = 4,
                    ResultantPFHdId = 1,
                    CalculatedPFHd = 0.00000001,
                    DateTimeCreated = System.DateTime.Now,
                    CurrentStateId = 16,
                }
            );

            #endregion

            #region Data for system tables

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    IsValid = true,
                    Name = "Observer",
                    NormalizedName = "OBSERVER",
                },
                new Role()
                {
                    Id = 2,
                    IsValid = true,
                    Name = "NormalUser",
                    NormalizedName = "NORMALUSER",
                },
                new Role()
                {
                    Id = 3,
                    IsValid = true,
                    Name = "SafetyEvaluationAdmin",
                    NormalizedName = "SAFETYEVALUATIONADMIN",
                },
                new Role()
                {
                    Id = 4,
                    IsValid = true,
                    Name = "UserAdmin",
                    NormalizedName = "USERADMIN",
                }
            );

            modelBuilder.Entity<Entity>().HasData(
                new Entity()
                {
                    Id = 1,
                    Name = "AccessPoint",
                },
                new Entity()
                {
                    Id = 2,
                    Name = "Element",
                },
                new Entity()
                {
                    Id = 3,
                    Name = "Machine",
                },
                new Entity()
                {
                    Id = 4,
                    Name = "SafetyFunction",
                },
                new Entity()
                {
                    Id = 5,
                    Name = "Subsystem",
                },
                new Entity()
                {
                    Id = 6,
                    Name = "User",
                }
            );

            modelBuilder.Entity<State>().HasData(
                 
                #region States for machines

                new State()
                {
                    Id = 1,
                    NameCZ = "Nová",
                    NameEN = "New",
                    DescriptionCZ = "Počáteční stav - řídící jednotka není vybrána",
                    DescriptionEN = "Initial state - conrol system is not selected",
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 2,
                    NameCZ = "Rozpracovaná",
                    NameEN = "Work in progres",
                    DescriptionCZ = "Pracuje se na detailech",
                    DescriptionEN = "Working on details",
                    StateNumber = 2,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 3,
                    NameCZ = "S vybranou řídící jednotkou",
                    NameEN = "With selected control system",
                    DescriptionCZ = "Řídící jednotka byla vybrána",
                    DescriptionEN = "Control system was selected",
                    StateNumber = 3,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 4,
                    NameCZ = "Vyhodnocená - validní",
                    NameEN = "Evaluated - valid",
                    DescriptionCZ = "Všechny bezpečnostní funkce splňují požadavky",
                    DescriptionEN = "All safety functions meet the requirements",
                    StateNumber = 4,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 5,
                    NameCZ = "Vyhodnocená - invalidní",
                    NameEN = "Evaluated - invalid",
                    DescriptionCZ = "Některé bezpečnostní funkce nesplňují požadavky",
                    DescriptionEN = "Some safety functions do not meet the requirements",
                    StateNumber = 5,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 6,
                    NameCZ = "Upravená",
                    NameEN = "Modified",
                    DescriptionCZ = "Vyhodnocená bezpečnostní funkce byla upravená - požadované opětovné vyhodnocení bezpečnosti",
                    DescriptionEN = "The evaluated safety function has been modified - required re-evaluation of safety",
                    StateNumber = 6,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },

                #endregion

                #region States for access points

                new State()
                {
                    Id = 7,
                    NameCZ = "Nový",
                    NameEN = "New",
                    DescriptionCZ = "Počáteční stav - bez bezpečnostní funkce",
                    DescriptionEN = "Initial state - without safety function",
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 1,
                },
                new State()
                {
                    Id = 8,
                    NameCZ = "Rozpracovaný",
                    NameEN = "Work in progress",
                    DescriptionCZ = "Pracuje se na detailech",
                    DescriptionEN = "Working on details",
                    StateNumber = 2,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 1,
                },
                new State()
                {
                    Id = 9,
                    NameCZ = "Ošetřený bezpečnostní funkcí",
                    NameEN = "Protected with safety function",
                    DescriptionCZ = "Přístupový bod má jednu nebo více bezpečnostních funkcí",
                    DescriptionEN = "Access point has one or more safety functions",
                    StateNumber = 3,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 1,
                },
                new State()
                {
                    Id = 10,
                    NameCZ = "Neošetřený bezpečnostní funkcí",
                    NameEN = "Not protected with safety function",
                    DescriptionCZ = "Přístupový bod nemá bezpečnostní funkce",
                    DescriptionEN = "Access point has no safety functions",
                    StateNumber = 4,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 1,
                },

                #endregion

                #region States for safety functions

                new State()
                {
                    Id = 11,
                    NameCZ = "Nová",
                    NameEN = "New",
                    DescriptionCZ = "Počáteční stav - s nevyplnenými subsystémami",
                    DescriptionEN = "Initial state - subsystems are not filled",
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 4,
                },
                new State()
                {
                    Id = 12,
                    NameCZ = "Rozpracovaná",
                    NameEN = "Work in progress",
                    DescriptionCZ = "Příprava subsystému",
                    DescriptionEN = "Preparing subsystems",
                    StateNumber = 2,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 4,
                },
                new State()
                {
                    Id = 13,
                    NameCZ = "Připravená na vyhodnocení",
                    NameEN = "Ready for evaluation",
                    DescriptionCZ = "Vstupní i výstupní subsystém je vyplněn",
                    DescriptionEN = "Input and output subsystems are completed",
                    StateNumber = 3,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 4,
                },
                new State()
                {
                    Id = 14,
                    NameCZ = "Vyhodnocená - validní",
                    NameEN = "Evaluated - valid",
                    DescriptionCZ = "Výsledná úroveň bezpečnosti splňuje požadavky - další úpravy nejsou povoleny",
                    DescriptionEN = "Determined final level of security meets the requirements - additional modifications are not allowed",
                    StateNumber = 4,
                    IsValid = true,
                    InitialState = false,
                    FinalState = true,
                    EntityId = 4,
                },

                #endregion

                #region States for subsystems

                new State()
                {
                    Id = 15,
                    NameCZ = "Použitý",
                    NameEN = "Used in safety function",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 5,
                },
                new State()
                {
                    Id = 16,
                    NameCZ = "Nepoužitý",
                    NameEN = "Not used in safety function",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 2,
                    IsValid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 5,
                },

                #endregion

                #region State for elements

                new State()
                {
                    Id = 17,
                    NameCZ = "Validní",
                    NameEN = "Valid",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = true,
                    FinalState = true,
                    EntityId = 2,
                },

                #endregion

                #region States for users

                new State()
                {
                    Id = 18,
                    NameCZ = "Aktivní",
                    NameEN = "Active",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    IsValid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 6,
                },
                new State()
                {
                    Id = 19,
                    NameCZ = "Zablokovaný",
                    NameEN = "Blocked",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 2,
                    IsValid = true,
                    InitialState = false,
                    FinalState = true,
                    EntityId = 6,
                }

                #endregion
            );

            #endregion
        }
    }
}
