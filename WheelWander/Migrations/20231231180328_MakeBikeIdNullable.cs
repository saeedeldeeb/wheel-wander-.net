using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WheelWander.Migrations
{
    public partial class MakeBikeIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locks_Bikes_BikeId",
                table: "Locks");

            migrationBuilder.AlterColumn<string>(
                name: "BikeId",
                table: "Locks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Locks_Bikes_BikeId",
                table: "Locks",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locks_Bikes_BikeId",
                table: "Locks");

            migrationBuilder.AlterColumn<string>(
                name: "BikeId",
                table: "Locks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locks_Bikes_BikeId",
                table: "Locks",
                column: "BikeId",
                principalTable: "Bikes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
