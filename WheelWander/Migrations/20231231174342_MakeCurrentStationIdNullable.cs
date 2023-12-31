using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WheelWander.Migrations
{
    public partial class MakeCurrentStationIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Stations_CurrentStationId",
                table: "Bikes");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStationId",
                table: "Bikes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Stations_CurrentStationId",
                table: "Bikes",
                column: "CurrentStationId",
                principalTable: "Stations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Stations_CurrentStationId",
                table: "Bikes");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStationId",
                table: "Bikes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Stations_CurrentStationId",
                table: "Bikes",
                column: "CurrentStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
