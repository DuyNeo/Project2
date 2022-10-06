using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class Diem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "soCotDiem",
                table: "scores");

            migrationBuilder.DropColumn(
                name: "soCotDiemBatBuoc",
                table: "scores");

            migrationBuilder.DropColumn(
                name: "sourseName",
                table: "scores");

            migrationBuilder.DropColumn(
                name: "subjectsName",
                table: "scores");

            migrationBuilder.RenameColumn(
                name: "subjectScore",
                table: "scores",
                newName: "UserId");

            migrationBuilder.AddColumn<float>(
                name: "Diem",
                table: "scores",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_scores_UserId",
                table: "scores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_scores_users_UserId",
                table: "scores",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scores_users_UserId",
                table: "scores");

            migrationBuilder.DropIndex(
                name: "IX_scores_UserId",
                table: "scores");

            migrationBuilder.DropColumn(
                name: "Diem",
                table: "scores");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "scores",
                newName: "subjectScore");

            migrationBuilder.AddColumn<int>(
                name: "soCotDiem",
                table: "scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "soCotDiemBatBuoc",
                table: "scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sourseName",
                table: "scores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subjectsName",
                table: "scores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
