using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insector.Data.Migrations
{
    public partial class ChangingTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRight_Rights_RoleId",
                table: "RoleRight");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleRight_UserRights_RightId",
                table: "RoleRight");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Rights_RoleId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserRights");

            migrationBuilder.DropIndex(
                name: "IX_Rights_UserId",
                table: "Rights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleRight",
                table: "RoleRight");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rights");

            migrationBuilder.RenameTable(
                name: "RoleRight",
                newName: "RolesRights");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRight_RoleId",
                table: "RolesRights",
                newName: "IX_RolesRights_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleRight_RightId",
                table: "RolesRights",
                newName: "IX_RolesRights_RightId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Rights",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolesRights",
                table: "RolesRights",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_Rights_RightsId",
                table: "RightRole",
                column: "RightsId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RightRole_Roles_RolesId",
                table: "RightRole",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesRights_Rights_RightId",
                table: "RolesRights",
                column: "RightId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolesRights_Roles_RoleId",
                table: "RolesRights",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_Rights_RightsId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RightRole_Roles_RolesId",
                table: "RightRole");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesRights_Rights_RightId",
                table: "RolesRights");

            migrationBuilder.DropForeignKey(
                name: "FK_RolesRights_Roles_RoleId",
                table: "RolesRights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolesRights",
                table: "RolesRights");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Rights");

            migrationBuilder.RenameTable(
                name: "RolesRights",
                newName: "RoleRight");

            migrationBuilder.RenameIndex(
                name: "IX_RolesRights_RoleId",
                table: "RoleRight",
                newName: "IX_RoleRight_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolesRights_RightId",
                table: "RoleRight",
                newName: "IX_RoleRight_RightId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rights",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleRight",
                table: "RoleRight",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRights", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rights_UserId",
                table: "Rights",
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

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRight_Rights_RoleId",
                table: "RoleRight",
                column: "RoleId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleRight_UserRights_RightId",
                table: "RoleRight",
                column: "RightId",
                principalTable: "UserRights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Rights_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Rights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
