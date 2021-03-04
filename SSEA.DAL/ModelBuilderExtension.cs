using Microsoft.EntityFrameworkCore;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.Common;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.PL;
using SSEA.DAL.Entities.SafetyEvaluation.CodeListEntities.SIL;
using SSEA.DAL.Entities.SafetyEvaluation.MainEntities;
using SSEA.DAL.Entities.System;
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
            // TODO: add DateTimeCreated, IdCreated properties
            // TODO: replace fake data in Category

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

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Label = "B",
                    DescriptionCZ = "Random text",
                    RequirementsCZ = "Random text",
                    FailureBehaviorCZ = "Random text",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = false,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 2,
                    MinDCId = 1,
                    MaxDCId = 1,
                },
                new Category()
                {
                    Id = 2,
                    Label = "1",
                    DescriptionCZ = "Random text",
                    RequirementsCZ = "Random text",
                    FailureBehaviorCZ = "Random text",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = false,
                    MinMTTFdId = 3,
                    MaxMTTFdId = 3,
                    MinDCId = 1,
                    MaxDCId = 1,
                },
                new Category()
                {
                    Id = 3,
                    Label = "2",
                    DescriptionCZ = "Random text",
                    RequirementsCZ = "Random text",
                    FailureBehaviorCZ = "Random text",
                    Logic = true,
                    Channels = 1,
                    RelevantCCF = true,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 3,
                    MinDCId = 2,
                    MaxDCId = 3,
                },
                new Category()
                {
                    Id = 4,
                    Label = "3",
                    DescriptionCZ = "Random text",
                    RequirementsCZ = "Random text",
                    FailureBehaviorCZ = "Random text",
                    Logic = true,
                    Channels = 2,
                    RelevantCCF = true,
                    MinMTTFdId = 1,
                    MaxMTTFdId = 3,
                    MinDCId = 2,
                    MaxDCId = 3,
                },
                new Category()
                {
                    Id = 5,
                    Label = "4",
                    DescriptionCZ = "Random text",
                    RequirementsCZ = "Random text",
                    FailureBehaviorCZ = "Random text",
                    Logic = true,
                    Channels = 2,
                    RelevantCCF = true,
                    MinMTTFdId = 3,
                    MaxMTTFdId = 3,
                    MinDCId = 4,
                    MaxDCId = 4,
                }
            );

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
                },
                new DC()
                {
                    Id = 2,
                    ValueCZ = "Nízké",
                    Min = 60,
                    Max = 90,
                },
                new DC()
                {
                    Id = 3,
                    ValueCZ = "Střední",
                    Min = 90,
                    Max = 99,
                },
                new DC()
                {
                    Id = 4,
                    ValueCZ = "Vysoké",
                    Min = 99,
                    Max = 100,
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
                    DescriptionCZ = "Jsou k vyloučení poruch se společnou pŕíčinou v konstrukci uvažovány výsledky režimu poruchy a nalýza účinku?",
                    TypeCZ = "Posouzení/analýza",
                    Points = 5,
                    ForPL = true,
                }

                // TODO: supply all data from table in norm EN ISO 13849-1 on page 74

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
                }

                // TODO: supply all data

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
                }

                #endregion
            );

            // TODO: add seeds for StateTransition ??

            #endregion
        }
    }
}
