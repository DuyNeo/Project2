using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class TeacherRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_RoleId",
                table: "teachers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_roles_RoleId",
                table: "teachers",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teachers_roles_RoleId",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_RoleId",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "teachers");
        }
    }
}
