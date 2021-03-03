using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddedProducerSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "CountryOfOrigin", "CurrentState_Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "Name" },
                values: new object[] { 1, "Germany", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, "Siemens" });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "CountryOfOrigin", "CurrentState_Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "Name" },
                values: new object[] { 2, "Slovakia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, "Sipron" });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "CountryOfOrigin", "CurrentState_Id", "DateTimeCreated", "DateTimeUpdated", "IdCreated", "IdUpdated", "Name" },
                values: new object[] { 3, "USA", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, "Allen Bradley" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
