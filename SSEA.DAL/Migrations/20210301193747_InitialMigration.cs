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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CFF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinCCF = table.Column<short>(type: "smallint", nullable: false),
                    MaxCCF = table.Column<short>(type: "smallint", nullable: false),
                    Beta = table.Column<double>(type: "float", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFF", x => x.Id);
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    DescriptionCZ = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norm", x => x.Id);
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pr", x => x.Id);
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    NameCZ = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Channels = table.Column<short>(type: "smallint", nullable: false),
                    RelevantCCF = table.Column<bool>(type: "bit", nullable: false),
                    MinMTTFd_Id = table.Column<int>(type: "int", nullable: false),
                    MaxMTTFd_Id = table.Column<int>(type: "int", nullable: false),
                    MinDC_Id = table.Column<int>(type: "int", nullable: false),
                    MaxDC_Id = table.Column<int>(type: "int", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Channels = table.Column<short>(type: "smallint", nullable: false),
                    MinSFF = table.Column<double>(type: "float", nullable: false),
                    MaxSFF = table.Column<double>(type: "float", nullable: false),
                    HFT = table.Column<short>(type: "smallint", nullable: false),
                    MaxPFHd_Id = table.Column<int>(type: "int", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    InitialState = table.Column<bool>(type: "bit", nullable: false),
                    FinalState = table.Column<bool>(type: "bit", nullable: false),
                    Entity_Id = table.Column<int>(type: "int", nullable: false)
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
                    MaxPL_Id = table.Column<int>(type: "int", nullable: false),
                    MaxCategory_Id = table.Column<int>(type: "int", nullable: false),
                    MaxSIL_Id = table.Column<int>(type: "int", nullable: false),
                    MaxArchitecture_Id = table.Column<int>(type: "int", nullable: false),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producer_SY_State_CurrentState_Id",
                        column: x => x.CurrentState_Id,
                        principalTable: "SY_State",
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
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
                    TypeOfSubsystem_Id = table.Column<int>(type: "int", nullable: false),
                    ValidCCF = table.Column<bool>(type: "bit", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: true),
                    MTTFdResult_Id = table.Column<int>(type: "int", nullable: true),
                    DCresult_Id = table.Column<int>(type: "int", nullable: true),
                    PLresult_Id = table.Column<int>(type: "int", nullable: true),
                    T1 = table.Column<double>(type: "float", nullable: true),
                    T2 = table.Column<double>(type: "float", nullable: true),
                    HFT = table.Column<double>(type: "float", nullable: true),
                    SFFresult = table.Column<short>(type: "smallint", nullable: false),
                    Architecture_Id = table.Column<int>(type: "int", nullable: true),
                    PFHdResult_Id = table.Column<int>(type: "int", nullable: true),
                    CFF_Id = table.Column<int>(type: "int", nullable: true),
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Subsystem_CFF_CFF_Id",
                        column: x => x.CFF_Id,
                        principalTable: "CFF",
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
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: false),
                    NextState_Id = table.Column<int>(type: "int", nullable: false)
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
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
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
                    OrderNum = table.Column<short>(type: "smallint", nullable: false),
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyFunctionSubsystem", x => new { x.SafetyFunction_Id, x.Subsystem_Id });
                    table.ForeignKey(
                        name: "FK_SafetyFunctionSubsystem_SafetyFunction_SafetyFunction_Id",
                        column: x => x.SafetyFunction_Id,
                        principalTable: "SafetyFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafetyFunctionSubsystem_Subsystem_Subsystem_Id",
                        column: x => x.Subsystem_Id,
                        principalTable: "Subsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubsystemCCF",
                columns: table => new
                {
                    Subsystem_Id = table.Column<int>(type: "int", nullable: false),
                    CCF_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsystemCCF", x => new { x.Subsystem_Id, x.CCF_Id });
                    table.ForeignKey(
                        name: "FK_SubsystemCCF_CCF_CCF_Id",
                        column: x => x.CCF_Id,
                        principalTable: "CCF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubsystemCCF_Subsystem_Subsystem_Id",
                        column: x => x.Subsystem_Id,
                        principalTable: "Subsystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IdCreated = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUpdated = table.Column<int>(type: "int", nullable: true),
                    DateTimeUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentState_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessPoint_Machine_Machine_Id",
                        column: x => x.Machine_Id,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineNorm", x => new { x.Machine_Id, x.Norm_Id });
                    table.ForeignKey(
                        name: "FK_MachineNorm_Machine_Machine_Id",
                        column: x => x.Machine_Id,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineNorm_Norm_Norm_Id",
                        column: x => x.Norm_Id,
                        principalTable: "Norm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementSFF",
                columns: table => new
                {
                    Element_Id = table.Column<int>(type: "int", nullable: false),
                    SFF_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSFF", x => new { x.Element_Id, x.SFF_Id });
                    table.ForeignKey(
                        name: "FK_ElementSFF_Element_Element_Id",
                        column: x => x.Element_Id,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementSFF_SFF_SFF_Id",
                        column: x => x.SFF_Id,
                        principalTable: "SFF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessPointSafetyFunction",
                columns: table => new
                {
                    AccessPoint_Id = table.Column<int>(type: "int", nullable: false),
                    SafetyFunction_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPointSafetyFunction", x => new { x.AccessPoint_Id, x.SafetyFunction_Id });
                    table.ForeignKey(
                        name: "FK_AccessPointSafetyFunction_AccessPoint_AccessPoint_Id",
                        column: x => x.AccessPoint_Id,
                        principalTable: "AccessPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessPointSafetyFunction_SafetyFunction_SafetyFunction_Id",
                        column: x => x.SafetyFunction_Id,
                        principalTable: "SafetyFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Av",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nemožné", null, 0, null, true, (short)5 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pradvěpodobné", null, 0, null, true, (short)1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Možné za určitých podmínek", null, 0, null, true, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "CCF",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "ForPL", "IdCreated", "IdUpdated", "IsValid", "Points", "TypeCZ", "TypeEN" },
                values: new object[,]
                {
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jsou k vyloučení poruch se společnou pŕíčinou v konstrukci uvažovány výsledky režimu poruchy a nalýza účinku?", null, true, 0, null, true, 5L, "Posouzení/analýza", null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fyzické oddělení medzi jednotlivými dráhami signálu", null, true, 0, null, true, 15L, "Oddělení/segregace", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jsou použity osvědčené součásti", null, true, 0, null, true, 5L, "Konstrukce/použití/zkušenosti", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ochrana proti přepětí, přetlaku, nadproudu, atd.", null, true, 0, null, true, 15L, "Konstrukce/použití/zkušenosti", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jsou použity ruzné technologie/konstrukce nebo fyzikální principy", null, true, 0, null, true, 20L, "Diverzita", null }
                });

            migrationBuilder.InsertData(
                table: "CFF",
                columns: new[] { "Id", "Beta", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "MaxCCF", "MinCCF" },
                values: new object[,]
                {
                    { 4, 0.01, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)100, (short)85 },
                    { 3, 0.02, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)85, (short)65 },
                    { 1, 0.10000000000000001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)35, (short)0 },
                    { 2, 0.050000000000000003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)65, (short)35 }
                });

            migrationBuilder.InsertData(
                table: "DC",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "Max", "Min", "ValueCZ", "ValueEN" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)100, (short)99, "Vysoké", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)99, (short)90, "Střední", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)90, (short)60, "Nízké", null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)60, (short)0, "Žádné", null }
                });

            migrationBuilder.InsertData(
                table: "EvaluationMethod",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "NameCZ", "NameEN", "Shortcut" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Úroveň vlastností", "Performance Level", "PL" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Úroveň integrity bezpečnosti", "Safety Integrity Level", "SIL" }
                });

            migrationBuilder.InsertData(
                table: "F",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Častá až nepřetržitá", null, 0, null, true, "F2" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Řídká až málo častá", null, 0, null, true, "F1" }
                });

            migrationBuilder.InsertData(
                table: "Fr",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "FrequencyOfThreatCZ", "FrequencyOfThreatEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1h až <= 1 den", null, 0, null, true, (short)5 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<= 1h", null, 0, null, true, (short)5 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 2 týdny až <= 1 rok", null, 0, null, true, (short)3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1 rok", null, 0, null, true, (short)2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1 den až <= 2 týdny", null, 0, null, true, (short)4 }
                });

            migrationBuilder.InsertData(
                table: "MTTFd",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "Max", "Min", "ValueCZ", "ValueEN" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)10, (short)3, "Krátká", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)30, (short)10, "Střední", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, (short)100, (short)30, "Dlouhá", null }
                });

            migrationBuilder.InsertData(
                table: "MachineType",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nějaký popis", null, 0, null, true, "Montážní linka", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nějaký popis", null, 0, null, true, "Víceúčelový stroj", null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nějaký popis", null, 0, null, true, "Jednoúčelový stroj", null }
                });

            migrationBuilder.InsertData(
                table: "Norm",
                columns: new[] { "Id", "CatalogNumber", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "Label", "NameCZ", "NameEN", "NormCategory" },
                values: new object[,]
                {
                    { 3, "15296296", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "ČSN EN 62061", "Popis tejto normy", null, "B1" },
                    { 2, "15296296", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "ČSN EN ISO 12100", "Popis tejto normy", null, "A" },
                    { 1, "15296296", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "ČSN EN ISO 13849-1", "Bezpečnost strojních zařízení - Bezpečnostné části ovládacích systému - Část 1: Všeobecné zásady pro konstrukci", null, "B1" }
                });

            migrationBuilder.InsertData(
                table: "P",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Možné za určitých podmínek", null, 0, null, true, "P1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sotva možné", null, 0, null, true, "P2" }
                });

            migrationBuilder.InsertData(
                table: "PFHd",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "MaxPFHd", "MinPFHd", "ValueSIL" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, 1E-05f, 1E-06f, (short)2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, 0.0001f, 1E-05f, (short)1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, 1E-06f, 1E-07f, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "PL",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "Label" },
                values: new object[,]
                {
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "e" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "d" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "c" }
                });

            migrationBuilder.InsertData(
                table: "PL",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "Label" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "b" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "a" }
                });

            migrationBuilder.InsertData(
                table: "Pr",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Možná", null, 0, null, true, (short)3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zanedbatelná", null, 0, null, true, (short)1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Výjimečná", null, 0, null, true, (short)2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pravděpodobná", null, 0, null, true, (short)4 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Velmi vysoká", null, 0, null, true, (short)5 }
                });

            migrationBuilder.InsertData(
                table: "S",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Závažné", null, 0, null, true, "S2" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lehké", null, 0, null, true, "S1" }
                });

            migrationBuilder.InsertData(
                table: "SFF",
                columns: new[] { "Id", "ComponentNameCZ", "ComponentNameEN", "DateTimeCreated", "DateTimeUpdated", "FailureModeCZ", "FailureModeEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kontakty nelze rozepnout", null, 0, null, true, 10L },
                    { 2, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kontakty nelze sepnout", null, 0, null, true, 10L },
                    { 3, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Současný zkrat mezi třemi kontakty přepínacího spínače", null, 0, null, true, 10L }
                });

            migrationBuilder.InsertData(
                table: "SY_Entity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "User" },
                    { 5, "SafetyFunction" },
                    { 4, "Producer" },
                    { 3, "Machine" },
                    { 2, "Element" },
                    { 1, "AccessPoint" },
                    { 6, "Subsystem" }
                });

            migrationBuilder.InsertData(
                table: "Se",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Přechodné: vyžadující ošetření na první pomoci", null, 0, null, true, (short)1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Přechodné: vyžadující ošetření praktickým lékařem", null, 0, null, true, (short)2 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trvalé: smrt, ztráta oka nebo paže", null, 0, null, true, (short)4 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trvalé: zlomená končetina, ztráta prstu", null, 0, null, true, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfFunction",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0, null, true, "Funkce místního ovládaní", null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0, null, true, "Funkce bezpečného zastavení iniciována bezpečnostním zařízením", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0, null, true, "Funkce ručního opětného nastavení", null }
                });

            migrationBuilder.InsertData(
                table: "TypeOfSubsystem",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "NameCZ", "NameEN" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Komunikační", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Logický", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Výstupní", null },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, true, "Vstupní", null }
                });

            migrationBuilder.InsertData(
                table: "Architecture",
                columns: new[] { "Id", "Channels", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "Diagnostic", "HFT", "IdCreated", "IdUpdated", "IsValid", "Label", "Logic", "MaxPFHd_Id", "MaxSFF", "MinSFF" },
                values: new object[,]
                {
                    { 1, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, (short)0, 0, null, true, "A", true, 1, 99.0, 60.0 },
                    { 2, (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, (short)1, 0, null, true, "B", true, 1, 99.0, 0.0 },
                    { 3, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, true, (short)0, 0, null, true, "C", true, 1, 99.0, 60.0 },
                    { 4, (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, true, (short)1, 0, null, true, "D", true, 1, 99.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Channels", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "FailureBehaviorCZ", "FailureBehaviorEN", "IdCreated", "IdUpdated", "IsValid", "Label", "Logic", "MaxDC_Id", "MaxMTTFd_Id", "MinDC_Id", "MinMTTFd_Id", "RelevantCCF", "RequirementsCZ", "RequirementsEN" },
                values: new object[,]
                {
                    { 1, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Random text", null, "Random text", null, 0, null, true, "B", true, 1, 2, 1, 1, false, "Random text", null },
                    { 2, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Random text", null, "Random text", null, 0, null, true, "1", true, 1, 3, 1, 3, false, "Random text", null },
                    { 3, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Random text", null, "Random text", null, 0, null, true, "2", true, 3, 3, 2, 1, true, "Random text", null },
                    { 4, (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Random text", null, "Random text", null, 0, null, true, "3", true, 3, 3, 2, 1, true, "Random text", null },
                    { 5, (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Random text", null, "Random text", null, 0, null, true, "4", true, 4, 3, 4, 3, true, "Random text", null }
                });

            migrationBuilder.InsertData(
                table: "SY_State",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "Entity_Id", "FinalState", "InitialState", "NameCZ", "NameEN", "StateNumber", "Valid" },
                values: new object[,]
                {
                    { 5, "Bez bezpečnostní funkce", "Without safety function", 1, false, true, "Nový", "New", 1, true },
                    { 6, "Přístupový bod má jednu nebo více bezpečnostních funkcí", "Access point has one or more safety functions", 1, false, false, "Ošetřený bezpečnostní funkcí", "Protected with safety function", 2, true },
                    { 7, "Přístupový bod byl odstránený", "Access point was deleted", 1, true, false, "Odstránený", "Removed", 3, true },
                    { 1, "Řídící jednotka není vybrána", "Conrol logic is not selected", 3, false, true, "Nová", "New", 1, true },
                    { 2, "Pracuje se na detailech", "Working on details", 3, false, false, "Rozpracovaná", "Work in progres", 2, true },
                    { 3, "Řídící jednotka byla vybrána", "Control logic was selected", 3, false, false, "Dokončená", "Completed", 3, true },
                    { 4, "Mašina byla odstránená", "Machine was deleted", 3, true, false, "Odstránená", "Removed", 4, true }
                });

            migrationBuilder.InsertData(
                table: "TypeOfLogic",
                columns: new[] { "Id", "AccessPointsMaxCount", "Communication", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "EthernetAdressesMaxCount", "IdCreated", "IdUpdated", "IsValid", "MaxArchitecture_Id", "MaxCategory_Id", "MaxPL_Id", "MaxSIL_Id", "NameCZ", "NameEN", "SI", "SO" },
                values: new object[,]
                {
                    { 1, 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0L, 0, null, true, 4, 5, 5, 1, "Relé", "Relay", 4, 4 },
                    { 2, 5, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 0L, 0, null, true, 4, 5, 5, 1, "CR30", "CR30", 12, 10 },
                    { 3, null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 48L, 0, null, true, 4, 5, 5, 1, "GMX", "GMX", 6144, 6144 },
                    { 4, null, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 256L, 0, null, true, 4, 5, 5, 1, "GLX", "GLX", 65536, 65536 }
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
                name: "IX_Producer_CurrentState_Id",
                table: "Producer",
                column: "CurrentState_Id");

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
                name: "IX_Subsystem_CFF_Id",
                table: "Subsystem",
                column: "CFF_Id");

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
                name: "CFF");

            migrationBuilder.DropTable(
                name: "TypeOfSubsystem");

            migrationBuilder.DropTable(
                name: "SY_State");

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
