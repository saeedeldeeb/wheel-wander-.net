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
                    { "0de8240e-0bfc-492d-9758-d041c1314812", "cbc9140b-09c4-46d6-8680-1c662261310b", "User", "USER" },
                    { "fcdb4a01-a1be-4d5b-92e4-08b1163f47c7", "91a602d5-1248-41e1-b01d-430c4e568a99", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c621b1c-a866-4726-8e6a-a170b9c03472", 0, "c04289f8-997d-4af2-ae82-8d8196f3bf36", "showmanAhmed@gmail.com", true, false, null, "SHOWMANAHMED@GMAIL.COM", "SHOWMANAHMED", "AQAAAAEAACcQAAAAEJMV9VCshKszIFsoWcxpczRuoQftB4Cfp/Sb+mGHCBDVV1esSjdXeNpuMVu6KOxgeg==", null, false, "", false, "showmanAhmed" },
                    { "accd2e8c-8355-4be6-b14d-d92e16529648", 0, "e37426de-151a-4492-8a42-0cb19b5b7759", "saeedeldeeb1@gmail.com", true, false, null, "SAEEDELDEEB1@GMAIL.COM", "SAEEDELDEEB1", "AQAAAAEAACcQAAAAEHGr9U9enKf2md9m8LFTL7y+kRJ/05KfgYGdMtf3rrnlE2TxQB8563gJOhZLGqAV8g==", null, false, "", false, "saeedeldeeb1" }
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
