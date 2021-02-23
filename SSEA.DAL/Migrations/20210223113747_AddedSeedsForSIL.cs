using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddedSeedsForSIL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Av",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nemožné", null, 0, null, false, (short)5 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Možné za určitých podmínek", null, 0, null, false, (short)3 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pradvěpodobné", null, 0, null, false, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "CFF",
                columns: new[] { "Id", "Beta", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "MaxCCF", "MinCCF" },
                values: new object[,]
                {
                    { 1, 0.10000000000000001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, (short)35, (short)0 },
                    { 2, 0.050000000000000003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, (short)65, (short)35 },
                    { 3, 0.02, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, (short)85, (short)65 },
                    { 4, 0.01, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, (short)100, (short)85 }
                });

            migrationBuilder.InsertData(
                table: "Fr",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "FrequencyOfThreatCZ", "FrequencyOfThreatEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "<= 1h", null, 0, null, false, (short)5 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1h až <= 1 den", null, 0, null, false, (short)5 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1 den až <= 2 týdny", null, 0, null, false, (short)4 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 2 týdny až <= 1 rok", null, 0, null, false, (short)3 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "> 1 rok", null, 0, null, false, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "PFHd",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "IsValid", "MaxPFHd", "MinPFHd", "ValueSIL" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, 0.0001f, 1E-05f, (short)1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, 1E-05f, 1E-06f, (short)2 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, false, 1E-06f, 1E-07f, (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Pr",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Velmi vysoká", null, 0, null, false, (short)5 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pravděpodobná", null, 0, null, false, (short)4 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Možná", null, 0, null, false, (short)3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Výjimečná", null, 0, null, false, (short)2 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Zanedbatelná", null, 0, null, false, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "SFF",
                columns: new[] { "Id", "ComponentNameCZ", "ComponentNameEN", "DateTimeCreated", "DateTimeUpdated", "FailureModeCZ", "FailureModeEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kontakty nelze rozepnout", null, 0, null, false, 10L },
                    { 2, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kontakty nelze sepnout", null, 0, null, false, 10L },
                    { 3, "Relé", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Současný zkrat mezi třemi kontakty přepínacího spínače", null, 0, null, false, 10L }
                });

            migrationBuilder.InsertData(
                table: "Se",
                columns: new[] { "Id", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "DescriptionEN", "IdCreated", "IdUpdated", "IsValid", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trvalé: smrt, ztráta oka nebo paže", null, 0, null, false, (short)4 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trvalé: zlomená končetina, ztráta prstu", null, 0, null, false, (short)3 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Přechodné: vyžadující ošetření praktickým lékařem", null, 0, null, false, (short)2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Přechodné: vyžadující ošetření na první pomoci", null, 0, null, false, (short)1 }
                });

            migrationBuilder.InsertData(
                table: "Architecture",
                columns: new[] { "Id", "Channels", "DateTimeCreated", "DateTimeUpdated", "DescriptionCZ", "Diagnostic", "HFT", "IdCreated", "IdUpdated", "IsValid", "Label", "Logic", "MaxPFHd_Id", "MaxSFF", "MinSFF" },
                values: new object[,]
                {
                    { 1, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, (short)0, 0, null, false, "A", true, 1, 99.0, 60.0 },
                    { 2, (short)2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, (short)1, 0, null, false, "B", true, 1, 99.0, 0.0 },
                    { 3, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, (short)0, 0, null, false, "C", true, 1, 99.0, 60.0 },
                    { 4, (short)1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, (short)1, 0, null, false, "D", true, 1, 99.0, 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Architecture",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Architecture",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Architecture",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Architecture",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Av",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Av",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Av",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CFF",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CFF",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CFF",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CFF",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fr",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fr",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fr",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fr",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fr",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PFHd",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PFHd",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pr",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pr",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pr",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pr",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pr",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SFF",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SFF",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SFF",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Se",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Se",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Se",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Se",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PFHd",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
