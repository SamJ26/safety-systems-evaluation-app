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
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                    Label = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NameCZ = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CatalogNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    Description = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FailureBehavior = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
