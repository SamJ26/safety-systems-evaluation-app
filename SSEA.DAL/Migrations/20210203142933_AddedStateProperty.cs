using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddedStateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentState_Id",
                table: "Subsystem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState_Id",
                table: "SafetyFunction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState_Id",
                table: "Machine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState_Id",
                table: "Element",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentState_Id",
                table: "AccessPoint",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subsystem_CurrentState_Id",
                table: "Subsystem",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyFunction_CurrentState_Id",
                table: "SafetyFunction",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_CurrentState_Id",
                table: "Machine",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_CurrentState_Id",
                table: "Element",
                column: "CurrentState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPoint_CurrentState_Id",
                table: "AccessPoint",
                column: "CurrentState_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessPoint_SY_State_CurrentState_Id",
                table: "AccessPoint",
                column: "CurrentState_Id",
                principalTable: "SY_State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_SY_State_CurrentState_Id",
                table: "Element",
                column: "CurrentState_Id",
                principalTable: "SY_State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_SY_State_CurrentState_Id",
                table: "Machine",
                column: "CurrentState_Id",
                principalTable: "SY_State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyFunction_SY_State_CurrentState_Id",
                table: "SafetyFunction",
                column: "CurrentState_Id",
                principalTable: "SY_State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subsystem_SY_State_CurrentState_Id",
                table: "Subsystem",
                column: "CurrentState_Id",
                principalTable: "SY_State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessPoint_SY_State_CurrentState_Id",
                table: "AccessPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_SY_State_CurrentState_Id",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_SY_State_CurrentState_Id",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_SafetyFunction_SY_State_CurrentState_Id",
                table: "SafetyFunction");

            migrationBuilder.DropForeignKey(
                name: "FK_Subsystem_SY_State_CurrentState_Id",
                table: "Subsystem");

            migrationBuilder.DropIndex(
                name: "IX_Subsystem_CurrentState_Id",
                table: "Subsystem");

            migrationBuilder.DropIndex(
                name: "IX_SafetyFunction_CurrentState_Id",
                table: "SafetyFunction");

            migrationBuilder.DropIndex(
                name: "IX_Machine_CurrentState_Id",
                table: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Element_CurrentState_Id",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_AccessPoint_CurrentState_Id",
                table: "AccessPoint");

            migrationBuilder.DropColumn(
                name: "CurrentState_Id",
                table: "Subsystem");

            migrationBuilder.DropColumn(
                name: "CurrentState_Id",
                table: "SafetyFunction");

            migrationBuilder.DropColumn(
                name: "CurrentState_Id",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "CurrentState_Id",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "CurrentState_Id",
                table: "AccessPoint");
        }
    }
}
