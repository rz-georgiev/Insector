using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insector.Data.Migrations
{
    public partial class AddingUserRightsalter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserRights_RightId",
                table: "UserRights",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRights_UserId",
                table: "UserRights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRights_Rights_RightId",
                table: "UserRights",
                column: "RightId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRights_Users_UserId",
                table: "UserRights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRights_Rights_RightId",
                table: "UserRights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRights_Users_UserId",
                table: "UserRights");

            migrationBuilder.DropIndex(
                name: "IX_UserRights_RightId",
                table: "UserRights");

            migrationBuilder.DropIndex(
                name: "IX_UserRights_UserId",
                table: "UserRights");
        }
    }
}
