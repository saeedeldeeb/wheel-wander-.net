using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WheelWander.Migrations
{
    public partial class MakeSomeRentalsColumnsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Stations_EndStationId",
                table: "Rentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedAt",
                table: "Rentals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EndStationId",
                table: "Rentals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Stations_EndStationId",
                table: "Rentals",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Stations_EndStationId",
                table: "Rentals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndedAt",
                table: "Rentals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndStationId",
                table: "Rentals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Stations_EndStationId",
                table: "Rentals",
                column: "EndStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
