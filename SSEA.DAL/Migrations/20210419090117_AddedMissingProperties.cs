using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEA.DAL.Migrations
{
    public partial class AddedMissingProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UsedOnMachine",
                table: "SafetyFunction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "SummedSFF",
                table: "Element",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "64076b79-d637-4a0a-9923-777627d07637");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8e615fc8-036f-425d-a896-2039b71d15d7");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f06ca3a4-62a6-43c1-b218-31dce70c0f16");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2889e719-1964-4394-a927-b7c313fc0a5a");

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 19, 11, 1, 15, 489, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 19, 11, 1, 15, 492, DateTimeKind.Local).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 19, 11, 1, 15, 492, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 19, 11, 1, 15, 492, DateTimeKind.Local).AddTicks(5846));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedOnMachine",
                table: "SafetyFunction");

            migrationBuilder.DropColumn(
                name: "SummedSFF",
                table: "Element");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f9a9c068-2961-4e69-954f-be3e16ffa144");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "213f4fef-bdb5-4c4c-8e4b-9f05915e9beb");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "cf697e61-319c-46b9-b2ae-a5820164bb23");

            migrationBuilder.UpdateData(
                table: "SY_Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9a1290cf-bb0f-4002-8664-c2b58e9bfd5d");

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 11, 13, 28, 46, 375, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 11, 13, 28, 46, 378, DateTimeKind.Local).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 11, 13, 28, 46, 378, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "Subsystem",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTimeCreated",
                value: new DateTime(2021, 4, 11, 13, 28, 46, 378, DateTimeKind.Local).AddTicks(1261));
        }
    }
}
