using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WheelWander.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0de8240e-0bfc-492d-9758-d041c1314812", "678e1b6a-9a0c-4fdd-8bca-130ee693e2ae", "User", "USER" },
                    { "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7", "217ca5d6-29ce-4c73-8b92-de50c09f97f0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c621b1c-a866-4726-8e6a-a170b9c03472", 0, "d33e4e53-cb92-411a-bec6-1de8f9463b0c", "showmanAhmed@gmail.com", true, false, null, "SHOWMANAHMED@GMAIL.COM", "SHOWMANAHMED", "AQAAAAEAACcQAAAAEJ3oZqqQplbgosNBFkavHMEJsbc4169BRYbm5jED9IMan/8U7ITr2+JRxWxkmryQCQ==", null, false, "", false, "showmanAhmed" },
                    { "accd2e8c-8355-4be6-b14d-d92e16529648", 0, "e36d365f-6b85-44a9-9a95-6a4d72e9a586", "saeedeldeeb1@gmail.com", true, false, null, "SAEEDELDEEB1@GMAIL.COM", "SAEEDELDEEB1", "AQAAAAEAACcQAAAAELtwAkdp2tkBKWYD6ed6ldNlmW0at8daYpulpOAozyyqmI4IBLjlmjM71EpoG9IMKg==", null, false, "", false, "saeedeldeeb1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0de8240e-0bfc-492d-9758-d041c1314812", "5c621b1c-a866-4726-8e6a-a170b9c03472" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7", "accd2e8c-8355-4be6-b14d-d92e16529648" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0de8240e-0bfc-492d-9758-d041c1314812", "5c621b1c-a866-4726-8e6a-a170b9c03472" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7", "accd2e8c-8355-4be6-b14d-d92e16529648" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0de8240e-0bfc-492d-9758-d041c1314812");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c621b1c-a866-4726-8e6a-a170b9c03472");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "accd2e8c-8355-4be6-b14d-d92e16529648");
        }
    }
}
