using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Av",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Av", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CCF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    ForPL = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueCZ = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ValueEN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Min = table.Column<short>(type: "smallint", nullable: false),
                    Max = table.Column<short>(type: "smallint", nullable: false),
                    CompareValue = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shortcut = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "F",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrequencyOfThreatCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FrequencyOfThreatEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTTFd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueCZ = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ValueEN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Min = table.Column<short>(type: "smallint", nullable: false),
                    Max = table.Column<short>(type: "smallint", nullable: false),
                    CompareValue = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTTFd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Norm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NameCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CatalogNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NormCategory = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationPrinciples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationPrinciples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "P",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PFHd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueSIL = table.Column<short>(type: "smallint", nullable: false),
                    MinPFHd = table.Column<float>(type: "real", nullable: false),
                    MaxPFHd = table.Column<float>(type: "real", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFHd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CompareValue = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Se",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<short>(type: "smallint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Se", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SFF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentNameCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FailureModeCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ComponentNameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FailureModeEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SY_Entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SY_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSubsystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSubsystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RequirementsCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RequirementsEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FailureBehaviorCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FailureBehaviorEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Logic = table.Column<bool>(type: "bit", nullable: false),
                    RelevantCCF = table.Column<bool>(type: "bit", nullable: false),
                    Channels = table.Column<short>(type: "smallint", nullable: false),
                    CompareValue = table.Column<short>(type: "smallint", nullable: false),
                    MinMTTFd_Id = table.Column<int>(type: "int", nullable: false),
                    MaxMTTFd_Id = table.Column<int>(type: "int", nullable: false),
                    MinDC_Id = table.Column<int>(type: "int", nullable: false),
                    MaxDC_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_DC_MaxDC_Id",
                        column: x => x.MaxDC_Id,
                        principalTable: "DC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_DC_MinDC_Id",
                        column: x => x.MinDC_Id,
                        principalTable: "DC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_MTTFd_MaxMTTFd_Id",
                        column: x => x.MaxMTTFd_Id,
                        principalTable: "MTTFd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_MTTFd_MinMTTFd_Id",
                        column: x => x.MinMTTFd_Id,
                        principalTable: "MTTFd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Architecture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Logic = table.Column<bool>(type: "bit", nullable: false),
                    Diagnostic = table.Column<bool>(type: "bit", nullable: false),
                    HFT = table.Column<short>(type: "smallint", nullable: false),
                    Channels = table.Column<short>(type: "smallint", nullable: false),
                    CompareValue = table.Column<short>(type: "smallint", nullable: false),
                    MinSFF = table.Column<double>(type: "float", nullable: false),
                    MaxSFF = table.Column<double>(type: "float", nullable: false),
                    MaxPFHd_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Architecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Architecture_PFHd_MaxPFHd_Id",
                        column: x => x.MaxPFHd_Id,
                        principalTable: "PFHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SY_State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StateNumber = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    InitialState = table.Column<bool>(type: "bit", nullable: false),
                    FinalState = table.Column<bool>(type: "bit", nullable: false),
                    Entity_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SY_State_SY_Entity_Entity_Id",
                        column: x => x.Entity_Id,
                        principalTable: "SY_Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SY_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SY_RoleClaim_SY_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SY_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfLogic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCZ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescriptionCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DescriptionEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SI = table.Column<int>(type: "int", nullable: false),
                    SO = table.Column<int>(type: "int", nullable: false),
                    Communication = table.Column<bool>(type: "bit", nullable: false),
                    AccessPointsMaxCount = table.Column<int>(type: "int", nullable: true),
                    EthernetAdressesMaxCount = table.Column<long>(type: "bigint", nullable: true),
                    Subsystem_Id = table.Column<int>(type: "int", nullable: false),
                    MaxPL_Id = table.Column<int>(type: "int", nullable: false),
                    MaxCategory_Id = table.Column<int>(type: "int", nullable: false),
                    MaxSIL_Id = table.Column<int>(type: "int", nullable: false),
                    MaxArchitecture_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfLogic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfLogic_Architecture_MaxArchitecture_Id",
                        column: x => x.MaxArchitecture_Id,
                        principalTable: "Architecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeOfLogic_Category_MaxCategory_Id",
                        column: x => x.MaxCategory_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeOfLogic_PFHd_MaxSIL_Id",
                        column: x => x.MaxSIL_Id,
                        principalTable: "PFHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeOfLogic_PL_MaxPL_Id",
                        column: x => x.MaxPL_Id,
                        principalTable: "PL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyFunction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfFunction_Id = table.Column<int>(type: "int", nullable: false),
                    EvaluationMethod_Id = table.Column<int>(type: "int", nullable: false),
                    PLr_Id = table.Column<int>(type: "int", nullable: true),
                    PLresult_Id = table.Column<int>(type: "int", nullable: true),
                    S_Id = table.Column<int>(type: "int", nullable: true),
                    F_Id = table.Column<int>(type: "int", nullable: true),
                    P_Id = table.Column<int>(type: "int", nullable: true),
                    SILCL_Id = table.Column<int>(type: "int", nullable: true),
                    SILresult_Id = table.Column<int>(type: "int", nullable: true),
                    Se_Id = table.Column<int>(type: "int", nullable: true),
                    Fr_Id = table.Column<int>(type: "int", nullable: true),
                    Pr_Id = table.Column<int>(type: "int", nullable: true),
                    Av_Id = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_Av_Av_Id",
                        column: x => x.Av_Id,
                        principalTable: "Av",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_EvaluationMethod_EvaluationMethod_Id",
                        column: x => x.EvaluationMethod_Id,
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_F_F_Id",
                        column: x => x.F_Id,
                        principalTable: "F",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_Fr_Fr_Id",
                        column: x => x.Fr_Id,
                        principalTable: "Fr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_P_P_Id",
                        column: x => x.P_Id,
                        principalTable: "P",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_PFHd_SILCL_Id",
                        column: x => x.SILCL_Id,
                        principalTable: "PFHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_PFHd_SILresult_Id",
                        column: x => x.SILresult_Id,
                        principalTable: "PFHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_PL_PLr_Id",
                        column: x => x.PLr_Id,
                        principalTable: "PL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_PL_PLresult_Id",
                        column: x => x.PLresult_Id,
                        principalTable: "PL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_Pr_Pr_Id",
                        column: x => x.Pr_Id,
                        principalTable: "Pr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_S_S_Id",
                        column: x => x.S_Id,
                        principalTable: "S",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_Se_Se_Id",
                        column: x => x.Se_Id,
                        principalTable: "Se",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunction_TypeOfFunction_TypeOfFunction_Id",
                        column: x => x.TypeOfFunction_Id,
                        principalTable: "TypeOfFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subsystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TypeOfSubsystem_Id = table.Column<int>(type: "int", nullable: false),
                    OperationPrinciple_Id = table.Column<int>(type: "int", nullable: false),
                    ValidCCF = table.Column<bool>(type: "bit", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: true),
                    MTTFdResult_Id = table.Column<int>(type: "int", nullable: true),
                    DCresult_Id = table.Column<int>(type: "int", nullable: true),
                    PLresult_Id = table.Column<int>(type: "int", nullable: true),
                    CFF = table.Column<double>(type: "float", nullable: false),
                    T1 = table.Column<double>(type: "float", nullable: true),
                    T2 = table.Column<double>(type: "float", nullable: true),
                    HFT = table.Column<double>(type: "float", nullable: true),
                    SFFresult = table.Column<short>(type: "smallint", nullable: false),
                    Architecture_Id = table.Column<int>(type: "int", nullable: true),
                    PFHdResult_Id = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsystem_Architecture_Architecture_Id",
                        column: x => x.Architecture_Id,
                        principalTable: "Architecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_DC_DCresult_Id",
                        column: x => x.DCresult_Id,
                        principalTable: "DC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_MTTFd_MTTFdResult_Id",
                        column: x => x.MTTFdResult_Id,
                        principalTable: "MTTFd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_OperationPrinciples_OperationPrinciple_Id",
                        column: x => x.OperationPrinciple_Id,
                        principalTable: "OperationPrinciples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_PFHd_PFHdResult_Id",
                        column: x => x.PFHdResult_Id,
                        principalTable: "PFHd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_PL_PLresult_Id",
                        column: x => x.PLresult_Id,
                        principalTable: "PL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsystem_TypeOfSubsystem_TypeOfSubsystem_Id",
                        column: x => x.TypeOfSubsystem_Id,
                        principalTable: "TypeOfSubsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SY_StateTransition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false),
                    NextState_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_StateTransition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SY_StateTransition_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SY_StateTransition_SY_State_NextState_Id",
                        column: x => x.NextState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SY_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SY_User_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Communication = table.Column<bool>(type: "bit", nullable: false),
                    HMI = table.Column<bool>(type: "bit", nullable: true),
                    PLC = table.Column<bool>(type: "bit", nullable: true),
                    MachineHelp = table.Column<bool>(type: "bit", nullable: true),
                    CodeProtection = table.Column<bool>(type: "bit", nullable: true),
                    SecurityOfSafetyParts = table.Column<bool>(type: "bit", nullable: true),
                    SafetyMasterInPlace = table.Column<bool>(type: "bit", nullable: true),
                    Producer_Id = table.Column<int>(type: "int", nullable: false),
                    EvaluationMethod_Id = table.Column<int>(type: "int", nullable: false),
                    MachineType_Id = table.Column<int>(type: "int", nullable: false),
                    TypeOfLogic_Id = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_EvaluationMethod_EvaluationMethod_Id",
                        column: x => x.EvaluationMethod_Id,
                        principalTable: "EvaluationMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machine_MachineType_MachineType_Id",
                        column: x => x.MachineType_Id,
                        principalTable: "MachineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machine_Producer_Producer_Id",
                        column: x => x.Producer_Id,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machine_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machine_TypeOfLogic_TypeOfLogic_Id",
                        column: x => x.TypeOfLogic_Id,
                        principalTable: "TypeOfLogic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B10d = table.Column<double>(type: "float", nullable: true),
                    CatalogNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Producer_Id = table.Column<int>(type: "int", nullable: false),
                    Subsystem_Id = table.Column<int>(type: "int", nullable: false),
                    DC_Id = table.Column<int>(type: "int", nullable: false),
                    Nop = table.Column<double>(type: "float", nullable: true),
                    Hop = table.Column<double>(type: "float", nullable: true),
                    Dop = table.Column<double>(type: "float", nullable: true),
                    Tcycles = table.Column<double>(type: "float", nullable: true),
                    MTTFdCounted = table.Column<double>(type: "float", nullable: true),
                    MTTFdResult_Id = table.Column<int>(type: "int", nullable: true),
                    C = table.Column<double>(type: "float", nullable: true),
                    LambdaC = table.Column<double>(type: "float", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Element_DC_DC_Id",
                        column: x => x.DC_Id,
                        principalTable: "DC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_MTTFd_MTTFdResult_Id",
                        column: x => x.MTTFdResult_Id,
                        principalTable: "MTTFd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Producer_Producer_Id",
                        column: x => x.Producer_Id,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Subsystem_Subsystem_Id",
                        column: x => x.Subsystem_Id,
                        principalTable: "Subsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyFunctionSubsystem",
                columns: table => new
                {
                    SafetyFunction_Id = table.Column<int>(type: "int", nullable: false),
                    Subsystem_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyFunctionSubsystem", x => new { x.SafetyFunction_Id, x.Subsystem_Id });
                    table.ForeignKey(
                        name: "FK_SafetyFunctionSubsystem_SafetyFunction_SafetyFunction_Id",
                        column: x => x.SafetyFunction_Id,
                        principalTable: "SafetyFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SafetyFunctionSubsystem_Subsystem_Subsystem_Id",
                        column: x => x.Subsystem_Id,
                        principalTable: "Subsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubsystemCCF",
                columns: table => new
                {
                    Subsystem_Id = table.Column<int>(type: "int", nullable: false),
                    CCF_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsystemCCF", x => new { x.Subsystem_Id, x.CCF_Id });
                    table.ForeignKey(
                        name: "FK_SubsystemCCF_CCF_CCF_Id",
                        column: x => x.CCF_Id,
                        principalTable: "CCF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubsystemCCF_Subsystem_Subsystem_Id",
                        column: x => x.Subsystem_Id,
                        principalTable: "Subsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SY_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SY_UserClaim_SY_User_UserId",
                        column: x => x.UserId,
                        principalTable: "SY_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SY_UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_SY_UserLogin_SY_User_UserId",
                        column: x => x.UserId,
                        principalTable: "SY_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SY_UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SY_UserRole_SY_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SY_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SY_UserRole_SY_User_UserId",
                        column: x => x.UserId,
                        principalTable: "SY_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SY_UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SY_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_SY_UserToken_SY_User_UserId",
                        column: x => x.UserId,
                        principalTable: "SY_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Machine_Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessPoint_Machine_Machine_Id",
                        column: x => x.Machine_Id,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessPoint_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineNorm",
                columns: table => new
                {
                    Machine_Id = table.Column<int>(type: "int", nullable: false),
                    Norm_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineNorm", x => new { x.Machine_Id, x.Norm_Id });
                    table.ForeignKey(
                        name: "FK_MachineNorm_Machine_Machine_Id",
                        column: x => x.Machine_Id,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineNorm_Norm_Norm_Id",
                        column: x => x.Norm_Id,
                        principalTable: "Norm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementSFF",
                columns: table => new
                {
                    Element_Id = table.Column<int>(type: "int", nullable: false),
                    SFF_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSFF", x => new { x.Element_Id, x.SFF_Id });
                    table.ForeignKey(
                        name: "FK_ElementSFF_Element_Element_Id",
                        column: x => x.Element_Id,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementSFF_SFF_SFF_Id",
                        column: x => x.SFF_Id,
                        principalTable: "SFF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessPointSafetyFunction",
                columns: table => new
                {
                    AccessPoint_Id = table.Column<int>(type: "int", nullable: false),
                    SafetyFunction_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPointSafetyFunction", x => new { x.AccessPoint_Id, x.SafetyFunction_Id });
                    table.ForeignKey(
                        name: "FK_AccessPointSafetyFunction_AccessPoint_AccessPoint_Id",
                        column: x => x.AccessPoint_Id,
                        principalTable: "AccessPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessPointSafetyFunction_SafetyFunction_SafetyFunction_Id",
                        column: x => x.SafetyFunction_Id,
                        principalTable: "SafetyFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Av",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 3, "Pradvěpodobné", null, false, true, (short)1 },
                    { 2, "Možné za určitých podmínek", null, false, true, (short)3 },
                    { 1, "Nemožné", null, false, true, (short)5 }
                });

            migrationBuilder.InsertData(
                table: "CCF",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "ForPL", "IsRemoved", "IsValid", "Points", "TypeCZ", "TypeEN" },
                values: new object[,]
                {
                    { 5, "Jsou k vyloučení poruch se společnou příčinou v konstrukci uvažovány výsledky režimu poruchy a analýza účinku?", null, true, false, true, 5L, "Posouzení/analýza", null },
                    { 1, "Fyzické oddělení medzi jednotlivými dráhami signálu", null, true, false, true, 15L, "Oddělení/segregace", null },
                    { 2, "Jsou použity ruzné technologie/konstrukce nebo fyzikální principy", null, true, false, true, 20L, "Diverzita", null },
                    { 3, "Ochrana proti přepětí, přetlaku, nadproudu, atd.", null, true, false, true, 15L, "Konstrukce/použití/zkušenosti", null },
                    { 4, "Jsou použity osvědčené součásti", null, true, false, true, 5L, "Konstrukce/použití/zkušenosti", null },
                    { 6, "Byli konstruktéři/údržbáři zacvičení k pochopení příčin a následkú poruch se společnou příčinou ?", null, true, false, true, 5L, "Zpusobilost/zácvik", null },
                    { 7, "Zamezení kontaminace a elektromagnetická kompatibilita (EMC) proti CCF podle příslušných norem", null, true, false, true, 25L, "Prostředí", null },
                    { 8, "Byly uvažováni požadavky na odolnost proti všem relevantním vlivum prostředí, např. teplota, vibrace, vlhkost ?", null, true, false, true, 10L, "Prostředí", null }
                });

            migrationBuilder.InsertData(
                table: "DC",
                columns: new[] { "Id", "CompareValue", "IsRemoved", "IsValid", "Max", "Min", "ValueCZ", "ValueEN" },
                values: new object[,]
                {
                    { 3, (short)3, false, true, (short)99, (short)90, "Střední", null },
                    { 2, (short)2, false, true, (short)90, (short)60, "Nízké", null },
                    { 1, (short)1, false, true, (short)60, (short)0, "Žádné", null },
                    { 4, (short)4, false, true, (short)100, (short)99, "Vysoké", null }
                });

            migrationBuilder.InsertData(
                table: "EvaluationMethod",
                columns: new[] { "Id", "IsRemoved", "IsValid", "NameCZ", "NameEN", "Shortcut" },
                values: new object[,]
                {
                    { 2, false, true, "Úroveň integrity bezpečnosti", "Safety Integrity Level", "SIL" },
                    { 1, false, true, "Úroveň vlastností", "Performance Level", "PL" }
                });

            migrationBuilder.InsertData(
                table: "F",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, "Řídká až málo častá", null, false, true, "F1" },
                    { 2, "Častá až nepřetržitá", null, false, true, "F2" }
                });

            migrationBuilder.InsertData(
                table: "Fr",
                columns: new[] { "Id", "FrequencyOfThreatCZ", "FrequencyOfThreatEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 3, "> 1 den až <= 2 týdny", null, false, true, (short)4 },
                    { 4, "> 2 týdny až <= 1 rok", null, false, true, (short)3 },
                    { 5, "> 1 rok", null, false, true, (short)2 },
                    { 1, "<= 1h", null, false, true, (short)5 },
                    { 2, "> 1h až <= 1 den", null, false, true, (short)5 }
                });

            migrationBuilder.InsertData(
                table: "MTTFd",
                columns: new[] { "Id", "CompareValue", "IsRemoved", "IsValid", "Max", "Min", "ValueCZ", "ValueEN" },
                values: new object[,]
                {
                    { 2, (short)2, false, true, (short)30, (short)10, "Střední", null },
                    { 3, (short)3, false, true, (short)100, (short)30, "Dlouhá", null },
                    { 1, (short)1, false, true, (short)10, (short)3, "Krátká", null }
                });

            migrationBuilder.InsertData(
                table: "MachineType",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 1, null, null, false, true, "Jednoúčelový stroj", null },
                    { 2, null, null, false, true, "Víceúčelový stroj", null },
                    { 3, null, null, false, true, "Montážní linka", null }
                });

            migrationBuilder.InsertData(
                table: "Norm",
                columns: new[] { "Id", "CatalogNumber", "IsRemoved", "IsValid", "Label", "NameCZ", "NameEN", "NormCategory" },
                values: new object[,]
                {
                    { 7, "unknown", false, true, "ISO 29042", "Obsažené látky - Hodnocení emisí nebezpečných látek přenášených vzduchem", null, "B" },
                    { 30, "unknown", false, true, "ISO 4413", "Napájecí zdroj - Hydraulická zařízení", null, "B" },
                    { 31, "unknown", false, true, "ISO 14118", "Řidicí systémy - Zamezení neočekávanému spuštění", null, "B" },
                    { 32, "unknown", false, true, "ISO 13849-1", "Řidicí systémy - Konstrukcde bezpečnostních částí ovládacího systémů", null, "B" },
                    { 33, "unknown", false, true, "ISO 13849-2", "Řidicí systémy - Ověřovani bezpečnostních častí ovládacích systémů", null, "B" },
                    { 34, "unknown", false, true, "ISO 13850", "Řidicí systémy - Funkce nouzového zastavení", null, "B" },
                    { 35, "unknown", false, true, "ISO 14120", "Bezpečnostní zařízení - Ochranné kryty", null, "B" },
                    { 36, "unknown", false, true, "ISO 14119", "Bezpečnostní zařízení - Blokovací zařízení spojená s ochrannými kryty", null, "B" },
                    { 38, "unknown", false, true, "IEC 61496", "Bezpečnostní zařízení - Elektrická snímací ochranná zařízení", null, "B" },
                    { 29, "unknown", false, true, "ISO 4414", "Napájecí zdroj - Pneumatická zařízení", null, "B" },
                    { 39, "unknown", false, true, "ISO 13856", "Bezpečnostní zařízení - Ochranná zařízení citlivá na tlak", null, "B" },
                    { 40, "unknown", false, true, "ISO 11161", "Bezpečnostní zařízení - Integrované výrobní systémy", null, "B" }
                });

            migrationBuilder.InsertData(
                table: "Norm",
                columns: new[] { "Id", "CatalogNumber", "IsRemoved", "IsValid", "Label", "NameCZ", "NameEN", "NormCategory" },
                values: new object[,]
                {
                    { 4, "unknown", false, true, "ISO 11546", "Rušení - Určovaní zvkové izolace krytů", null, "B" },
                    { 3, "unknown", false, true, "ISO 9614", "Rušení - Určovaní hladin akustického výkonu zdroju hluku pomocí akustické intenzity", null, "B" },
                    { 2, "unknown", false, true, "ISO 3741", "Rušení - Určení hladín akustického výkonu a hladin akusticko energie zdroju hluku", null, "B" },
                    { 1, "unknown", false, true, "ISO 11200", "Rušení - Určovaní emisních hladín akustického tlaku na stanovišti obsluhy", null, "B" },
                    { 37, "unknown", false, true, "ISO 13851", "Bezpečnostní zařízení -Dvouruční ovládací zařízení", null, "B" },
                    { 6, "unknown", false, true, "ISO 4871", "Rušení - Deklarování a ověřování hodnot emise hluku", null, "B" },
                    { 28, "unknown", false, true, "IEC 60204-1", "Napájecí zdroj - Elektrická zařízení", null, "B" },
                    { 26, "unknown", false, true, "ISO 7731", "Alarmy a varování - Sluchové výstražní signály", null, "B" },
                    { 8, "unknown", false, true, "ISO 14123-1", "Obsažené látky - Snižování ohroženými látkami emitovanými stojním zařízením", null, "B" },
                    { 9, "unknown", false, true, "ISO 14159", "Obsažené látky - Hygienické požadavky", null, "B" },
                    { 10, "unknown", false, true, "ISO 13732-1", "Tepelná rizika - Metody posuzování odezvy člověka na kontakt s horkými povrchy", null, "B" },
                    { 11, "unknown", false, true, "ISO 19363", "Požarní riziká - Požarní prevence a požarní ochrana", null, "B" },
                    { 12, "unknown", false, true, "IEC 60204-1", "Elektrická rizika - Ochrana proti zásahu elektrickým proudem", null, "B" },
                    { 13, "unknown", false, true, "ISO 2631", "Vibrace a rázy - Expozice celkovým vibracím", null, "B" },
                    { 5, "unknown", false, true, "ISO 11957", "Rušení - Určení zvukové izolace kabin", null, "B" },
                    { 15, "unknown", false, true, "ISO 20643", "Vibrace a rázy - Ruční a rukou vedená strojní zařizení", null, "B" },
                    { 27, "unknown", false, true, "IEC 61310-1", "Alarmy a varování - Požadavky na vizuální, akustické a taktilná signály", null, "B" },
                    { 16, "unknown", false, true, "ISO 15534", "Ergonomie - Přístupové otvory", null, "B" },
                    { 18, "unknown", false, true, "ISO 15536-1", "Ergonomie - Počítačové modely lidského těla a tělesné šablony", null, "B" },
                    { 19, "unknown", false, true, "ISO 11145", "Radiační rizika - Lasary a laserová zařízení - obecné požadavky", null, "B" },
                    { 20, "unknown", false, true, "ISO 13854", "Rozměry a vzdálenosti - Nejemenší mezery k zamezení stlačení částí lidského těla", null, "B" },
                    { 21, "unknown", false, true, "ISO 13855", "Rozměry a vzdálenosti - Minimální vzdálenosti", null, "B" },
                    { 22, "unknown", false, true, "ISO 13857", "Rozměry a vzdálenosti - Bezepečné vzdálenosti", null, "B" },
                    { 23, "unknown", false, true, "ISO 14122", "Rozměry a vzdálenosti - Trvalé prostředky přístupu ke strojním zařízením", null, "B" },
                    { 24, "unknown", false, true, "ISO 3864-1", "Alarmy a varování - Zásady navrhování bezpečnostních značek a bezpečnostního značení", null, "B" },
                    { 25, "unknown", false, true, "ISO 7010", "Alarmy a varování - Registrované bezpečnostní značky", null, "B" },
                    { 17, "unknown", false, true, "ISO 14738", "Ergonomie - Antropometrické požadavky na uspořádané pracovního místa u strojního zařízení", null, "B" },
                    { 14, "unknown", false, true, "ISO 13753", "Vibrace a rázy - Vibrace ruky a paže", null, "B" }
                });

            migrationBuilder.InsertData(
                table: "OperationPrinciples",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 1, null, null, false, true, "mechanický", null },
                    { 4, null, null, false, true, "elektromechanický", null },
                    { 3, null, null, false, true, "pneumatický", null },
                    { 2, null, null, false, true, "elektrický", null },
                    { 5, null, null, false, true, "hydraulický", null }
                });

            migrationBuilder.InsertData(
                table: "P",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, "Možné za určitých podmínek", null, false, true, "P1" },
                    { 2, "Sotva možné", null, false, true, "P2" }
                });

            migrationBuilder.InsertData(
                table: "PFHd",
                columns: new[] { "Id", "IsRemoved", "IsValid", "MaxPFHd", "MinPFHd", "ValueSIL" },
                values: new object[,]
                {
                    { 2, false, true, 1E-05f, 1E-06f, (short)2 },
                    { 1, false, true, 1E-06f, 1E-07f, (short)3 },
                    { 3, false, true, 0.0001f, 1E-05f, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "PL",
                columns: new[] { "Id", "CompareValue", "IsRemoved", "IsValid", "Label" },
                values: new object[,]
                {
                    { 1, (short)1, false, true, "a" },
                    { 2, (short)2, false, true, "b" },
                    { 3, (short)3, false, true, "c" },
                    { 4, (short)4, false, true, "d" }
                });

            migrationBuilder.InsertData(
                table: "PL",
                columns: new[] { "Id", "CompareValue", "IsRemoved", "IsValid", "Label" },
                values: new object[] { 5, (short)5, false, true, "e" });

            migrationBuilder.InsertData(
                table: "Pr",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, "Velmi vysoká", null, false, true, (short)5 },
                    { 2, "Pravděpodobná", null, false, true, (short)4 },
                    { 3, "Možná", null, false, true, (short)3 },
                    { 4, "Výjimečná", null, false, true, (short)2 },
                    { 5, "Zanedbatelná", null, false, true, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "CountryOfOrigin", "IsRemoved", "IsValid", "Name" },
                values: new object[,]
                {
                    { 3, "USA", false, true, "Allen Bradley" },
                    { 2, "Slovakia", false, true, "Sipron" },
                    { 1, "Germany", false, true, "Siemens" }
                });

            migrationBuilder.InsertData(
                table: "S",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 2, "Závažné", null, false, true, "S2" },
                    { 1, "Lehké", null, false, true, "S1" }
                });

            migrationBuilder.InsertData(
                table: "SFF",
                columns: new[] { "Id", "ComponentNameCZ", "ComponentNameEN", "FailureModeCZ", "FailureModeEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 31, "Bezdotykové spínače", null, "Selhíni spínače vlivem mechanické poruchy", null, false, true, 10L },
                    { 32, "Bezdotykové spínače", null, "Současný zkrat mezi třemi kontakty přepínacího spínače", null, false, true, 10L },
                    { 33, "Teplotní spínač", null, "Kontakty nelze rozepnout", null, false, true, 30L },
                    { 10, "Relé", null, "Současné zapnutí zapínacího a vypínacího kontaktu", null, false, true, 10L },
                    { 9, "Relé", null, "Současný zkrat mezi třemi kontakty přepínacího spínače", null, false, true, 10L },
                    { 8, "Relé", null, "Kontakty nelze sepnout", null, false, true, 10L },
                    { 7, "Relé", null, "Kontakty nelze rozepnout", null, false, true, 10L },
                    { 28, "Bezdotykové spínače", null, "Trvalé nízke rezistance na výstupu", null, false, true, 25L },
                    { 11, "Relé", null, "Zkrat medzi dvěma páry kontaktů a/nebo mezi kontakty a svorku cívky", null, false, true, 10L },
                    { 27, "Poistka", null, "Přerušený obvod", null, false, true, 90L },
                    { 26, "Poistka", null, "Nedojde k přtavení (zkrat)", null, false, true, 10L },
                    { 25, "Stykač", null, "Zkrat medzi dvěma páry kontaktů a/nebo medzi kontakty a svorku cívky", null, false, true, 10L },
                    { 24, "Stykač", null, "Současné zapnutí zapínacího a vypínacího kontaktu", null, false, true, 10L },
                    { 23, "Stykač", null, "Současný zkrat medzi třemi kontakty přepínacího spínače", null, false, true, 10L },
                    { 22, "Stykač", null, "Kontakty nelze sepnout", null, false, true, 10L },
                    { 21, "Stykač", null, "Kontakty nelze rozepnout", null, false, true, 10L },
                    { 20, "Stykač", null, "Všeschny Kontakty zůstávajé ve vypnuté poloze, je-li cívka pod napětím", null, false, true, 25L },
                    { 19, "Stykač", null, "Všechny kontakty zůstávají v zapnuté poloze, je-li cívka bez napětí", null, false, true, 25L },
                    { 18, "Jistič, proudový chránič", null, "Zkrat medzi dvěmi páry kontaktů a/nebo medzi kontakty a svorkou civky", null, false, true, 10L },
                    { 17, "Jistič, proudový chránič", null, "Současné zapnutí zapínacího a vypínacího kontaktu", null, false, true, 10L },
                    { 16, "Jistič, proudový chránič", null, "Současný zkrat medzi třemi kontakty přepínacího spínače", null, false, true, 10L },
                    { 15, "Jistič, proudový chránič", null, "Kontakty nelze sepnou", null, false, true, 10L },
                    { 14, "Jistič, proudový chránič", null, "Kontakty nelze rozepnout", null, false, true, 10L },
                    { 13, "Jistič, proudový chránič", null, "Všechny kontakty zůstavají ve vypnuté poloze, je-li cívka pod napětí", null, false, true, 25L },
                    { 12, "Jistič, proudový chránič", null, "Všechny kontakty zůstavají v zapnuté poloze, je-li cívka bez napětí", null, false, true, 25L },
                    { 30, "Bezdotykové spínače", null, "Přerušní napájaní", null, false, true, 30L },
                    { 29, "Bezdotykové spínače", null, "Trvalé vysoká rezistance na výstupu", null, false, true, 25L },
                    { 6, "Relé", null, "Všechny kontakty zůstavají ve vypnuté poloze, je-li cívka pod napětím", null, false, true, 25L },
                    { 48, "Solenoidový ventil", null, "Netěsnost", null, false, true, 65L },
                    { 4, "Elektromechanický konocový spínač, polohový spínač, koncový spínač, ručně ovladaný spínač atd.", null, "Kontakty nelze sepnout", null, false, true, 50L },
                    { 54, "Svorkovnice", null, "Rozpojený obvod svorek", null, false, true, 90L }
                });

            migrationBuilder.InsertData(
                table: "SFF",
                columns: new[] { "Id", "ComponentNameCZ", "ComponentNameEN", "FailureModeCZ", "FailureModeEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 53, "Svorkovnice", null, "Zkrat medzi sousedními svorkami", null, false, true, 10L },
                    { 52, "Vidlice a zásuvky, konektory", null, "Rozpojený obvod libovolného spoje (koliku) konektoru", null, false, true, 80L },
                    { 51, "Vidlice a zásuvky, konektory", null, "Zkrat libovolného vodiče s neživou částí", null, false, true, 10L },
                    { 50, "Vidlice a zásuvky, konektory", null, "Zkrat medzi libovolnými dvěma sousedními spoji (koliky)", null, false, true, 10L },
                    { 49, "Solenoidový ventil", null, "Další poruchové režimy (viz poznámka 4)", null, false, true, 10L },
                    { 34, "Teplotní spínač", null, "Kontakty nelze sepnout", null, false, true, 10L },
                    { 47, "Solenoidový ventil", null, "Změna doby spínaní", null, false, true, 5L },
                    { 5, "Relé", null, "Všechny kontakty zůstavají v zapnuté poloze, je-li cívka bez napětí", null, false, true, 25L },
                    { 45, "Solenoidový ventil", null, "Nelze nabudit", null, false, true, 5L },
                    { 44, "Tlakový spínač", null, "Změna meřícich nebo výstupních charakteristik", null, false, true, 20L },
                    { 46, "Solenoidový ventil", null, "Nelze odbudit", null, false, true, 15L },
                    { 42, "Tlakový spínač", null, "Současný zkat medzi třemi svorkami přepínacích kontaktů", null, false, true, 10L },
                    { 41, "Tlakový spínač", null, "Zkrat mezi sousedními kontakty", null, false, true, 10L },
                    { 40, "Tlakový spínač", null, "Kontakty nelze sepnout", null, false, true, 10L },
                    { 39, "Tlakový spínač", null, "Kontakty nelze rozepnout", null, false, true, 30L },
                    { 38, "Teplotní spínač", null, "Zmena měřích nebo výstupních charakteristik", null, false, true, 20L },
                    { 37, "Teplotní spínač", null, "Vada čidla", null, false, true, 20L },
                    { 36, "Teplotní spínač", null, "Zkrat medzi třemi svorkami přepínacích kontaktů", null, false, true, 10L },
                    { 1, "Spínač s nuceným vypínaním", null, "Kontakty nelze rozepnout", null, false, true, 20L },
                    { 2, "Spínač s nuceným vypínaním", null, "Kontakty nelze sepnout", null, false, true, 80L },
                    { 3, "Elektromechanický konocový spínač, polohový spínač, koncový spínač, ručně ovladaný spínač atd.", null, "Kontakty nelze rozepnout", null, false, true, 50L },
                    { 43, "Tlakový spínač", null, "Vada čidla", null, false, true, 20L },
                    { 35, "Teplotní spínač", null, "Zkrat medzi sousedními kontakty", null, false, true, 10L }
                });

            migrationBuilder.InsertData(
                table: "SY_Entity",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[,]
                {
                    { 1, false, "AccessPoint" },
                    { 2, false, "Element" },
                    { 3, false, "Machine" },
                    { 4, false, "SafetyFunction" },
                    { 6, false, "User" },
                    { 5, false, "Subsystem" }
                });

            migrationBuilder.InsertData(
                table: "SY_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsValid", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "8e40e214-1ec7-4798-b1ad-6df12ccc0983", true, "Observer", "OBSERVER" },
                    { 2, "3fddc30d-38ba-4445-9580-0e11450ba067", true, "NormalUser", "NORMALUSER" },
                    { 3, "a9440705-bcc6-41ab-af98-10add59a8c76", true, "SafetyEvaluationAdmin", "SAFETYEVALUATIONADMIN" },
                    { 4, "dfca4985-69b1-4091-8654-67530a7746b9", true, "UserAdmin", "USERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Se",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "Value" },
                values: new object[,]
                {
                    { 4, "Přechodné: vyžadující ošetření na první pomoci", null, false, true, (short)1 },
                    { 3, "Přechodné: vyžadující ošetření praktickým lékařem", null, false, true, (short)2 },
                    { 2, "Trvalé: zlomená končetina, ztráta prstu", null, false, true, (short)3 },
                    { 1, "Trvalé: smrt, ztráta oka nebo paže", null, false, true, (short)4 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfFunction",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 1, null, null, false, true, "Funkce bezpečného zastavení iniciována bezpečnostním zařízením", null },
                    { 2, null, null, false, true, "Funkce ručního opětného nastavení", null },
                    { 3, null, null, false, true, "Funkce místního ovládaní", null },
                    { 4, null, null, false, true, "Funkce spuštení/opětovného spuštení", null },
                    { 5, null, null, false, true, "Funkce vyřazení", null }
                });

            migrationBuilder.InsertData(
                table: "TypeOfFunction",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "IsRemoved", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 6, null, null, false, true, "Funkce tipování", null },
                    { 8, null, null, false, true, "Funkce zamezení neočekávaného spuštění", null },
                    { 9, null, null, false, true, "Únik a uvolnění zachycených osob", null },
                    { 10, null, null, false, true, "Funkce odpojení a uvolnění energie", null },
                    { 11, null, null, false, true, "Režimy ovládání a volba režimu", null },
                    { 12, null, null, false, true, "Vzájemné púsobení rúzných bezpečnostních částí ovládacího systému", null },
                    { 13, null, null, false, true, "Monitorování parametrizace hodnot bezpečnostního vstupu", null },
                    { 14, null, null, false, true, "Funkce nouzového zastavení", null },
                    { 7, null, null, false, true, "Funkce povelového zařízení", null }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSubsystem",
                columns: new[] { "Id", "IsRemoved", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 1, false, true, "Vstupní", "Input" },
                    { 2, false, true, "Výstupní", "Output" },
                    { 3, false, true, "Logický", "Logical" },
                    { 4, false, true, "Komunikace vstup-logika", "Input-logic comminucation" },
                    { 5, false, true, "Komunikace výstup-logika", "Output-logic comminucation" }
                });

            migrationBuilder.InsertData(
                table: "Architecture",
                columns: new[] { "Id", "Channels", "CompareValue", "DescriptionCZ", "DescriptionEN", "Diagnostic", "HFT", "IsRemoved", "IsValid", "Label", "Logic", "MaxPFHd_Id", "MaxSFF", "MinSFF" },
                values: new object[,]
                {
                    { 4, (short)2, (short)4, null, null, true, (short)1, false, true, "D", true, 1, 99.0, 0.0 },
                    { 3, (short)1, (short)3, null, null, true, (short)0, false, true, "C", true, 1, 99.0, 60.0 },
                    { 2, (short)2, (short)2, null, null, false, (short)1, false, true, "B", true, 1, 99.0, 0.0 },
                    { 1, (short)1, (short)1, null, null, false, (short)0, false, true, "A", true, 1, 99.0, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Channels", "CompareValue", "DescriptionCZ", "DescriptionEN", "FailureBehaviorCZ", "FailureBehaviorEN", "IsRemoved", "IsValid", "Label", "Logic", "MaxDC_Id", "MaxMTTFd_Id", "MinDC_Id", "MinMTTFd_Id", "RelevantCCF", "RequirementsCZ", "RequirementsEN" },
                values: new object[,]
                {
                    { 1, (short)1, (short)1, null, null, null, null, false, true, "B", true, 1, 2, 1, 1, false, null, null },
                    { 4, (short)2, (short)4, null, null, null, null, false, true, "3", true, 3, 3, 2, 1, true, null, null },
                    { 3, (short)1, (short)3, null, null, null, null, false, true, "2", true, 3, 3, 2, 1, true, null, null },
                    { 2, (short)1, (short)2, null, null, null, null, false, true, "1", true, 1, 3, 1, 3, false, null, null },
                    { 5, (short)2, (short)5, null, null, null, null, false, true, "4", true, 4, 3, 4, 3, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "SY_State",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "Entity_Id", "FinalState", "InitialState", "IsRemoved", "IsValid", "NameCZ", "NameEN", "StateNumber" },
                values: new object[,]
                {
                    { 10, "Počáteční stav - s nevyplnenými subsystémami", "Initial state - subsystems are not filled", 4, false, true, false, true, "Nová", "New", 1 },
                    { 16, null, null, 5, true, true, false, true, "Nepoužitý", "Not used in safety function", 2 },
                    { 15, null, null, 5, true, true, false, true, "Použitý", "Used in safety function", 1 },
                    { 14, "Výsledná úroveň bezpečnosti nesplňuje požadavky", "Determined final level of security does not meet the requirements", 4, true, false, false, true, "Vyhodnocená - invalidní", "Evaluated - invalid", 5 },
                    { 13, "Výsledná úroveň bezpečnosti splňuje požadavky", "Determined final level of security meets the requirements", 4, true, false, false, true, "Vyhodnocená - validní", "Evaluated - valid", 4 },
                    { 12, "Vstupní i výstupní subsystém je vyplněn", "Input and output subsystems are completed", 4, false, false, false, true, "Připravená na vyhodnocení", "Ready for evaluation", 3 },
                    { 11, "Příprava subsystému", "Preparing subsystems", 4, false, false, false, true, "Rozpracovaná", "Work in progress", 2 },
                    { 5, "Některé bezpečnostní funkce nesplňují požadavky", "Some safety functions do not meet the requirements", 3, true, false, false, true, "Vyhodnocená - invalidní", "Evaluated - invalid", 5 },
                    { 17, null, null, 2, false, true, false, true, "Validní", "Valid", 1 },
                    { 3, "Řídící jednotka byla vybrána", "Control system was selected", 3, false, false, false, true, "S vybranou řídící jednotkou", "With selected control system", 3 },
                    { 2, "Pracuje se na detailech", "Working on details", 3, false, false, false, true, "Rozpracovaná", "Work in progres", 2 },
                    { 1, "Počáteční stav - řídící jednotka není vybrána", "Initial state - conrol system is not selected", 3, false, true, false, true, "Nová", "New", 1 },
                    { 18, null, null, 6, false, true, false, true, "Aktivní", "Active", 1 },
                    { 9, "Přístupový bod nemá bezpečnostní funkce", "Access point has not any safety functions", 1, true, false, false, true, "Neošetřený bezpečnostní funkcí", "Not protected with safety function", 4 },
                    { 8, "Přístupový bod má jednu nebo více bezpečnostních funkcí", "Access point has one or more safety functions", 1, true, false, false, true, "Ošetřený bezpečnostní funkcí", "Protected with safety function", 3 },
                    { 7, "Pracuje se na detailech", "Working on details", 1, false, false, false, true, "Rozpracovaný", "Work in progress", 2 },
                    { 6, "Počáteční stav - bez bezpečnostní funkce", "Initial state - without safety function", 1, false, true, false, true, "Nový", "New", 1 },
                    { 4, "Všechny bezpečnostní funkce splňují požadavky", "All safety functions meet the requirements", 3, true, false, false, true, "Vyhodnocená - validní", "Evaluated - valid", 4 },
                    { 19, null, null, 6, true, false, false, true, "Zablokovaný", "Blocked", 2 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfLogic",
                columns: new[] { "Id", "AccessPointsMaxCount", "Communication", "DescriptionCZ", "DescriptionEN", "EthernetAdressesMaxCount", "IsRemoved", "IsValid", "MaxArchitecture_Id", "MaxCategory_Id", "MaxPL_Id", "MaxSIL_Id", "NameCZ", "NameEN", "SI", "SO", "Subsystem_Id" },
                values: new object[,]
                {
                    { 1, 2, false, null, null, 0L, false, true, 4, 5, 5, 1, "Relé", "Relay", 4, 4, 0 },
                    { 2, 5, false, null, null, 0L, false, true, 4, 5, 5, 1, "CR30", "CR30", 12, 10, 0 },
                    { 3, null, true, null, null, 48L, false, true, 4, 5, 5, 1, "GMX", "GMX", 6144, 6144, 0 },
                    { 4, null, true, null, null, 256L, false, true, 4, 5, 5, 1, "GLX", "GLX", 65536, 65536, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPoint_CurrentState_Id",
                table: "AccessPoint",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPoint_Machine_Id",
                table: "AccessPoint",
                column: "Machine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPointSafetyFunction_SafetyFunction_Id",
                table: "AccessPointSafetyFunction",
                column: "SafetyFunction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Architecture_MaxPFHd_Id",
                table: "Architecture",
                column: "MaxPFHd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MaxDC_Id",
                table: "Category",
                column: "MaxDC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MaxMTTFd_Id",
                table: "Category",
                column: "MaxMTTFd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MinDC_Id",
                table: "Category",
                column: "MinDC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MinMTTFd_Id",
                table: "Category",
                column: "MinMTTFd_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_CurrentState_Id",
                table: "Element",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_DC_Id",
                table: "Element",
                column: "DC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_MTTFdResult_Id",
                table: "Element",
                column: "MTTFdResult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Producer_Id",
                table: "Element",
                column: "Producer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Subsystem_Id",
                table: "Element",
                column: "Subsystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ElementSFF_SFF_Id",
                table: "ElementSFF",
                column: "SFF_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_CurrentState_Id",
                table: "Machine",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_EvaluationMethod_Id",
                table: "Machine",
                column: "EvaluationMethod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineType_Id",
                table: "Machine",
                column: "MachineType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Producer_Id",
                table: "Machine",
                column: "Producer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_TypeOfLogic_Id",
                table: "Machine",
                column: "TypeOfLogic_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MachineNorm_Norm_Id",
                table: "MachineNorm",
                column: "Norm_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_Av_Id",
                table: "SafetyFunction",
                column: "Av_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_CurrentState_Id",
                table: "SafetyFunction",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_EvaluationMethod_Id",
                table: "SafetyFunction",
                column: "EvaluationMethod_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_F_Id",
                table: "SafetyFunction",
                column: "F_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_Fr_Id",
                table: "SafetyFunction",
                column: "Fr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_P_Id",
                table: "SafetyFunction",
                column: "P_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_PLr_Id",
                table: "SafetyFunction",
                column: "PLr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_PLresult_Id",
                table: "SafetyFunction",
                column: "PLresult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_Pr_Id",
                table: "SafetyFunction",
                column: "Pr_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_S_Id",
                table: "SafetyFunction",
                column: "S_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_Se_Id",
                table: "SafetyFunction",
                column: "Se_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_SILCL_Id",
                table: "SafetyFunction",
                column: "SILCL_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_SILresult_Id",
                table: "SafetyFunction",
                column: "SILresult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_TypeOfFunction_Id",
                table: "SafetyFunction",
                column: "TypeOfFunction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunctionSubsystem_Subsystem_Id",
                table: "SafetyFunctionSubsystem",
                column: "Subsystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_Architecture_Id",
                table: "Subsystem",
                column: "Architecture_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_Category_Id",
                table: "Subsystem",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_CurrentState_Id",
                table: "Subsystem",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_DCresult_Id",
                table: "Subsystem",
                column: "DCresult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_MTTFdResult_Id",
                table: "Subsystem",
                column: "MTTFdResult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_OperationPrinciple_Id",
                table: "Subsystem",
                column: "OperationPrinciple_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_PFHdResult_Id",
                table: "Subsystem",
                column: "PFHdResult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_PLresult_Id",
                table: "Subsystem",
                column: "PLresult_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_TypeOfSubsystem_Id",
                table: "Subsystem",
                column: "TypeOfSubsystem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubsystemCCF_CCF_Id",
                table: "SubsystemCCF",
                column: "CCF_Id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "SY_Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SY_RoleClaim_RoleId",
                table: "SY_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SY_State_Entity_Id",
                table: "SY_State",
                column: "Entity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SY_StateTransition_CurrentState_Id",
                table: "SY_StateTransition",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SY_StateTransition_NextState_Id",
                table: "SY_StateTransition",
                column: "NextState_Id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "SY_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_SY_User_CurrentState_Id",
                table: "SY_User",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "SY_User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SY_UserClaim_UserId",
                table: "SY_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SY_UserLogin_UserId",
                table: "SY_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SY_UserRole_RoleId",
                table: "SY_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLogic_MaxArchitecture_Id",
                table: "TypeOfLogic",
                column: "MaxArchitecture_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLogic_MaxCategory_Id",
                table: "TypeOfLogic",
                column: "MaxCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLogic_MaxPL_Id",
                table: "TypeOfLogic",
                column: "MaxPL_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfLogic_MaxSIL_Id",
                table: "TypeOfLogic",
                column: "MaxSIL_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPointSafetyFunction");

            migrationBuilder.DropTable(
                name: "ElementSFF");

            migrationBuilder.DropTable(
                name: "MachineNorm");

            migrationBuilder.DropTable(
                name: "SafetyFunctionSubsystem");

            migrationBuilder.DropTable(
                name: "SubsystemCCF");

            migrationBuilder.DropTable(
                name: "SY_RoleClaim");

            migrationBuilder.DropTable(
                name: "SY_StateTransition");

            migrationBuilder.DropTable(
                name: "SY_UserClaim");

            migrationBuilder.DropTable(
                name: "SY_UserLogin");

            migrationBuilder.DropTable(
                name: "SY_UserRole");

            migrationBuilder.DropTable(
                name: "SY_UserToken");

            migrationBuilder.DropTable(
                name: "AccessPoint");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "SFF");

            migrationBuilder.DropTable(
                name: "Norm");

            migrationBuilder.DropTable(
                name: "SafetyFunction");

            migrationBuilder.DropTable(
                name: "CCF");

            migrationBuilder.DropTable(
                name: "SY_Role");

            migrationBuilder.DropTable(
                name: "SY_User");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Subsystem");

            migrationBuilder.DropTable(
                name: "Av");

            migrationBuilder.DropTable(
                name: "F");

            migrationBuilder.DropTable(
                name: "Fr");

            migrationBuilder.DropTable(
                name: "P");

            migrationBuilder.DropTable(
                name: "Pr");

            migrationBuilder.DropTable(
                name: "S");

            migrationBuilder.DropTable(
                name: "Se");

            migrationBuilder.DropTable(
                name: "TypeOfFunction");

            migrationBuilder.DropTable(
                name: "EvaluationMethod");

            migrationBuilder.DropTable(
                name: "MachineType");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "TypeOfLogic");

            migrationBuilder.DropTable(
                name: "OperationPrinciples");

            migrationBuilder.DropTable(
                name: "SY_State");

            migrationBuilder.DropTable(
                name: "TypeOfSubsystem");

            migrationBuilder.DropTable(
                name: "Architecture");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "PL");

            migrationBuilder.DropTable(
                name: "SY_Entity");

            migrationBuilder.DropTable(
                name: "PFHd");

            migrationBuilder.DropTable(
                name: "DC");

            migrationBuilder.DropTable(
                name: "MTTFd");
        }
    }
}
