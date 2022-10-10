using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class luong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tuitions_users_usersUserId",
                table: "tuitions");

            migrationBuilder.DropIndex(
                name: "IX_tuitions_usersUserId",
                table: "tuitions");

            migrationBuilder.DropColumn(
                name: "usersUserId",
                table: "tuitions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tuitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tuitions_UserId",
                table: "tuitions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tuitions_users_UserId",
                table: "tuitions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tuitions_users_UserId",
                table: "tuitions");

            migrationBuilder.DropIndex(
                name: "IX_tuitions_UserId",
                table: "tuitions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tuitions");

            migrationBuilder.AddColumn<int>(
                name: "usersUserId",
                table: "tuitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tuitions_usersUserId",
                table: "tuitions",
                column: "usersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tuitions_users_usersUserId",
                table: "tuitions",
                column: "usersUserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
