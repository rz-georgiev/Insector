using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insector.Data.Migrations
{
    public partial class SeedingDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { 1, "Default", "Default", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { 2, "Administrator", "Administrator", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "IsActive", "IsEmailConfirmed", "Nickname", "PasswordHash" },
                values: new object[] { 1, "https://cdn.icon-icons.com/icons2/1378/PNG/512/avatardefault_92824.png", "default_user@gmail.com", true, true, "Default", "AKuLcq62eEe910jv3QkLqqsajq3x6FkzziClOSSzc0TvF7RFQmwGRSH6ALZxs/HOMg==" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
