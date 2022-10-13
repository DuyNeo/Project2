using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassCode = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CouresName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TuitionFee = table.Column<double>(type: "float", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "holidaySchedules",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holidaySchedules", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "pointTypes",
                columns: table => new
                {
                    PointTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Coefficient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pointTypes", x => x.PointTypeId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SubjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_subjects_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subjects_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeachersCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCode = table.Column<int>(type: "int", nullable: false),
                    NumberPhone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    lop = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CoreSubject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Concurrently = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.TeachersId);
                    table.ForeignKey(
                        name: "FK_teachers_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Class_User_id",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "salaries",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryMoth = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_salaries_teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "teachers",
                        principalColumn: "TeachersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClassRoom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mon = table.Column<bool>(type: "bit", nullable: false),
                    Tue = table.Column<bool>(type: "bit", nullable: false),
                    Wed = table.Column<bool>(type: "bit", nullable: false),
                    Thu = table.Column<bool>(type: "bit", nullable: false),
                    Fri = table.Column<bool>(type: "bit", nullable: false),
                    Sat = table.Column<bool>(type: "bit", nullable: false),
                    Sun = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schedules_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diem = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PointTypeId = table.Column<int>(type: "int", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.ScoreId);
                    table.ForeignKey(
                        name: "FK_scores_pointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "pointTypes",
                        principalColumn: "PointTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scores_subjects_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scores_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tuitions",
                columns: table => new
                {
                    TuitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Training = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    TollType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeRate = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tuitions", x => x.TuitionId);
                    table.ForeignKey(
                        name: "FK_tuitions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_salaries_TeacherId",
                table: "salaries",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_SubjectId",
                table: "schedules",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_UserId",
                table: "schedules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_scores_PointTypeId",
                table: "scores",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_scores_SubjectsId",
                table: "scores",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_scores_UserId",
                table: "scores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_CourseId",
                table: "subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_DepartmentId",
                table: "subjects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_RoleId",
                table: "teachers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tuitions_UserId",
                table: "tuitions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ClassId",
                table: "users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "holidaySchedules");

            migrationBuilder.DropTable(
                name: "salaries");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "tuitions");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "pointTypes");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
