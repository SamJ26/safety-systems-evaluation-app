using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddingStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SY_State",
                columns: new[] { "Id", "DescriptionCZ", "DescriptionEN", "Entity_Id", "FinalState", "InitialState", "NameCZ", "NameEN", "StateNumber", "Valid" },
                values: new object[,]
                {
                    { 8, "S nevyplnenými subsystémami", "Subsystems are not filled", 1, false, true, "Nová", "New", 1, true },
                    { 9, "Příprava subsystému", "Preparing subsystems", 1, false, false, "Rozpracovaná", "Work in progress", 2, true },
                    { 10, "Určená výsledná úroveň bezpečnosti", "Determined final level of security", 1, false, false, "Dokončená", "Completed", 3, true },
                    { 11, "Bezpečnostní funkce byla odstránena", "Safety function was deleted", 1, false, false, "Odstránená", "Removed", 4, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SY_State",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SY_State",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SY_State",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SY_State",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
