﻿using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.Auth;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
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
                    Min = 3,
                    Max = 10,
                    CompareValue = 1,
                },
                new MTTFd()
                {
                    Id = 2,
                    ValueCZ = "Střední",
                    Min = 10,
                    Max = 30,
                    CompareValue = 2,
                },
                new MTTFd()
                {
                    Id = 3,
                    ValueCZ = "Dlouhá",
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
                    NameEN = "Input-logic comminucation",
                },
                new TypeOfSubsystem()
                {
                    Id = 5,
                    NameCZ = "Komunikace výstup-logika",
                    NameEN = "Output-logic comminucation",
                }
            );

            modelBuilder.Entity<OperationPrinciple>().HasData(
                new OperationPrinciple()
                {
                    Id = 1,
                    NameCZ = "mechanický",
                },
                new OperationPrinciple()
                {
                    Id = 2,
                    NameCZ = "elektrický",
                },
                new OperationPrinciple()
                {
                    Id = 3,
                    NameCZ = "pneumatický",
                },
                new OperationPrinciple()
                {
                    Id = 4,
                    NameCZ = "elektromechanický",
                },
                new OperationPrinciple()
                {
                    Id = 5,
                    NameCZ = "hydraulický",
                }
            );

            modelBuilder.Entity<MachineType>().HasData(
                new MachineType()
                {
                    Id = 1,
                    NameCZ = "Jednoúčelový stroj",
                },
                new MachineType()
                {
                    Id = 2,
                    NameCZ = "Víceúčelový stroj",
                },
                new MachineType()
                {
                    Id = 3,
                    NameCZ = "Montážní linka",
                }

                // TODO: supply all data

            );

            modelBuilder.Entity<Norm>().HasData(
                new Norm()
                {
                    Id = 1,
                    Label = "ČSN EN ISO 13849-1",
                    NameCZ = "Bezpečnost strojních zařízení - Bezpečnostné části ovládacích systému - Část 1: Všeobecné zásady pro konstrukci",
                    CatalogNumber = "15296296",
                    NormCategory = "B1",
                },
                new Norm()
                {
                    Id = 2,
                    Label = "ČSN EN ISO 12100",
                    NameCZ = "Popis tejto normy",
                    CatalogNumber = "15296296",
                    NormCategory = "A",
                },
                new Norm()
                {
                    Id = 3,
                    Label = "ČSN EN 62061",
                    NameCZ = "Popis tejto normy",
                    CatalogNumber = "15296296",
                    NormCategory = "B1",
                }

                // TODO: supply all data

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
                    Min = 0,
                    Max = 60,
                    CompareValue = 1,
                },
                new DC()
                {
                    Id = 2,
                    ValueCZ = "Nízké",
                    Min = 60,
                    Max = 90,
                    CompareValue = 2,
                },
                new DC()
                {
                    Id = 3,
                    ValueCZ = "Střední",
                    Min = 90,
                    Max = 99,
                    CompareValue = 3,
                },
                new DC()
                {
                    Id = 4,
                    ValueCZ = "Vysoké",
                    Min = 99,
                    Max = 100,
                    CompareValue = 4,
                }
            );

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
                },
                new TypeOfFunction()
                {
                    Id = 2,
                    NameCZ = "Funkce ručního opětného nastavení",
                },
                new TypeOfFunction()
                {
                    Id = 3,
                    NameCZ = "Funkce místního ovládaní",
                },
                new TypeOfFunction()
                {
                    Id = 4,
                    NameCZ = "Funkce spuštení/opětovného spuštení",
                },
                new TypeOfFunction()
                {
                    Id = 5,
                    NameCZ = "Funkce vyřazení",
                },
                new TypeOfFunction()
                {
                    Id = 6,
                    NameCZ = "Funkce tipování",
                },
                new TypeOfFunction()
                {
                    Id = 7,
                    NameCZ = "Funkce povelového zařízení",
                },
                new TypeOfFunction()
                {
                    Id = 8,
                    NameCZ = "Funkce zamezení neočekávaného spuštění",
                },
                new TypeOfFunction()
                {
                    Id = 9,
                    NameCZ = "Únik a uvolnění zachycených osob",
                },
                new TypeOfFunction()
                {
                    Id = 10,
                    NameCZ = "Funkce odpojení a uvolnění energie",
                },
                new TypeOfFunction()
                {
                    Id = 11,
                    NameCZ = "Režimy ovládání a volba režimu",
                },
                new TypeOfFunction()
                {
                    Id = 12,
                    NameCZ = "Vzájemné púsobení rúzných bezpečnostních částí ovládacího systému",
                },
                new TypeOfFunction()
                {
                    Id = 13,
                    NameCZ = "Monitorování parametrizace hodnot bezpečnostního vstupu",
                },
                new TypeOfFunction()
                {
                    Id = 14,
                    NameCZ = "Funkce nouzového zastavení",
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
                    Id = 3,
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
                    Name = "Producer",
                },
                new Entity()
                {
                    Id = 5,
                    Name = "SafetyFunction",
                },
                new Entity()
                {
                    Id = 6,
                    Name = "Subsystem",
                },
                new Entity()
                {
                    Id = 7,
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
                    DescriptionCZ = "Řídící jednotka není vybrána",
                    DescriptionEN = "Conrol logic is not selected",
                    StateNumber = 1,
                    Valid = true,
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
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 3,
                    NameCZ = "Dokončená",
                    NameEN = "Completed",
                    DescriptionCZ = "Řídící jednotka byla vybrána",
                    DescriptionEN = "Control logic was selected",
                    StateNumber = 3,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 3,
                },
                new State()
                {
                    Id = 4,
                    NameCZ = "Odstránená",
                    NameEN = "Removed",
                    DescriptionCZ = "Mašina byla odstránená",
                    DescriptionEN = "Machine was deleted",
                    StateNumber = 4,
                    Valid = true,
                    InitialState = false,
                    FinalState = true,
                    EntityId = 3,
                },

                #endregion

                #region States for access points

                new State()
                {
                    Id = 5,
                    NameCZ = "Nový",
                    NameEN = "New",
                    DescriptionCZ = "Bez bezpečnostní funkce",
                    DescriptionEN = "Without safety function",
                    StateNumber = 1,
                    Valid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 1,
                },
                new State()
                {
                    Id = 6,
                    NameCZ = "Ošetřený bezpečnostní funkcí",
                    NameEN = "Protected with safety function",
                    DescriptionCZ = "Přístupový bod má jednu nebo více bezpečnostních funkcí",
                    DescriptionEN = "Access point has one or more safety functions",
                    StateNumber = 2,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 1,
                },
                new State()
                {
                    Id = 7,
                    NameCZ = "Odstránený",
                    NameEN = "Removed",
                    DescriptionCZ = "Přístupový bod byl odstránený",
                    DescriptionEN = "Access point was deleted",
                    StateNumber = 3,
                    Valid = true,
                    InitialState = false,
                    FinalState = true,
                    EntityId = 1,
                },

                #endregion

                #region States for safety functions

                new State()
                {
                    Id = 8,
                    NameCZ = "Nová",
                    NameEN = "New",
                    DescriptionCZ = "S nevyplnenými subsystémami",
                    DescriptionEN = "Subsystems are not filled",
                    StateNumber = 1,
                    Valid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 5,
                },
                new State()
                {
                    Id = 9,
                    NameCZ = "Rozpracovaná",
                    NameEN = "Work in progress",
                    DescriptionCZ = "Příprava subsystému",
                    DescriptionEN = "Preparing subsystems",
                    StateNumber = 2,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 5,
                },
                new State()
                {
                    Id = 10,
                    NameCZ = "Dokončená",
                    NameEN = "Completed",
                    DescriptionCZ = "Určená výsledná úroveň bezpečnosti",
                    DescriptionEN = "Determined final level of security",
                    StateNumber = 3,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 5,
                },
                new State()
                {
                    Id = 11,
                    NameCZ = "Odstránená",
                    NameEN = "Removed",
                    DescriptionCZ = "Bezpečnostní funkce byla odstránena",
                    DescriptionEN = "Safety function was deleted",
                    StateNumber = 4,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 5,
                },

                #endregion

                #region States for users

                new State()
                {
                    Id = 12,
                    NameCZ = "Aktivní",
                    NameEN = "Active",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    Valid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 7,
                },
                new State()
                {
                    Id = 13,
                    NameCZ = "Zablokovaný",
                    NameEN = "Blocked",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 2,
                    Valid = true,
                    InitialState = false,
                    FinalState = false,
                    EntityId = 7,
                },

                #endregion

                #region States for subsystems

                new State()
                {
                    Id = 14,
                    NameCZ = "Nový",
                    NameEN = "New",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    Valid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 6,
                },

                #endregion

                #region State for elements

                new State()
                {
                    Id = 15,
                    NameCZ = "Nový",
                    NameEN = "New",
                    DescriptionCZ = null,
                    DescriptionEN = null,
                    StateNumber = 1,
                    Valid = true,
                    InitialState = true,
                    FinalState = false,
                    EntityId = 2,
                }

                #endregion

            );

            // TODO: add seeds for StateTransition ??

            #endregion
        }
    }
}
