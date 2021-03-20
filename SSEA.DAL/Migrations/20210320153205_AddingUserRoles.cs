using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddingUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SY_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsValid", "Name", "NormalizedName" },
                values: new object[] { 1, "afb81a7a-607d-40ca-82d4-9148b5ddf7cb", true, "Observer", "OBSERVER" });

            migrationBuilder.InsertData(
                table: "SY_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsValid", "Name", "NormalizedName" },
                values: new object[] { 2, "144fbeba-86df-462b-8dd1-08bdc7b02846", true, "NormalUser", "NORMALUSER" });

            migrationBuilder.InsertData(
                table: "SY_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsValid", "Name", "NormalizedName" },
                values: new object[] { 3, "c78c08cf-0ee3-4413-a9a9-3600fbfb8fc0", true, "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
