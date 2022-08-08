using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insector.Data.Migrations
{
    public partial class AddingUserRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_Rights_RightsId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_Role_RolesId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRights_Rights_RightId",
                table: "UserRights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRights_Users_UserId",
                table: "UserRights");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_UserRights_RightId",
                table: "UserRights");

            migrationBuilder.DropIndex(
                name: "IX_UserRights_UserId",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "RightId",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Rights");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UserRights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserRights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserRights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rights",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleRight_Rights_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRight_UserRights_RightId",
                        column: x => x.RightId,
                        principalTable: "UserRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Rights_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Rights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rights_UserId",
                table: "Rights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RightId",
                table: "RoleRight",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRight_RoleId",
                table: "RoleRight",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_Rights_RolesId",
                table: "RightRole",
                column: "RolesId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_UserRights_RightsId",
                table: "RightRole",
                column: "RightsId",
                principalTable: "UserRights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rights_Users_UserId",
                table: "Rights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_Rights_RolesId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_UserRights_RightsId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Rights_Users_UserId",
                table: "Rights");

            migrationBuilder.DropTable(
                name: "RoleRight");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Rights_UserId",
                table: "Rights");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserRights");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rights");

            migrationBuilder.AddColumn<int>(
                name: "RightId",
                table: "UserRights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserRights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Rights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserRights_RightId",
                table: "UserRights",
                column: "RightId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRights_UserId",
                table: "UserRights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_Rights_RightsId",
                table: "RightRole",
                column: "RightsId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_Role_RolesId",
                table: "RightRole",
                column: "RolesId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
