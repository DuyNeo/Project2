using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class MonHoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "boMonHoc",
                table: "subjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Subject",
                table: "subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "boMonHoc",
                table: "subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
