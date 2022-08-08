using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insector.Data.Migrations
{
    public partial class AddingUserRightsalter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Right_Users_UserId",
                table: "Right");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Right",
                table: "Right");

            migrationBuilder.DropIndex(
                name: "IX_Right_UserId",
                table: "Right");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Right");

            migrationBuilder.RenameTable(
                name: "Right",
                newName: "Rights");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rights",
                table: "Rights",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RightUser",
                columns: table => new
                {
                    RightsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightUser", x => new { x.RightsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RightUser_Rights_RightsId",
                        column: x => x.RightsId,
                        principalTable: "Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RightUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RightUser_UsersId",
                table: "RightUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RightUser");

            migrationBuilder.DropTable(
                name: "UserRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rights",
                table: "Rights");

            migrationBuilder.RenameTable(
                name: "Rights",
                newName: "Right");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Right",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Right",
                table: "Right",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Right_UserId",
                table: "Right",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Right_Users_UserId",
                table: "Right",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
