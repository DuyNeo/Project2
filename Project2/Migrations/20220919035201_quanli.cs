using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class quanli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khoaHocs",
                columns: table => new
                {
                    khoaHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoaHocMa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    khoaHocTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoaHocs", x => x.khoaHocId);
                });

            migrationBuilder.CreateTable(
                name: "loaiDiems",
                columns: table => new
                {
                    loaiDiemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loaiDiemTen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HeSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiDiems", x => x.loaiDiemId);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    idNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNguoiDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenDaydu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    chucDanh = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    matKhau = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.idNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "toBoMons",
                columns: table => new
                {
                    toBoMonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    toBoMonTen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toBoMons", x => x.toBoMonId);
                });

            migrationBuilder.CreateTable(
                name: "hocPhis",
                columns: table => new
                {
                    hocPhiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hocPhiNguoiDungId = table.Column<int>(type: "int", nullable: false),
                    lopHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    khoaDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thuPhi = table.Column<double>(type: "float", nullable: false),
                    loaiThuPhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mucThuPhi = table.Column<double>(type: "float", nullable: false),
                    giamGia = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocPhis", x => x.hocPhiId);
                    table.ForeignKey(
                        name: "FK_hocPhis_NguoiDung_hocPhiNguoiDungId",
                        column: x => x.hocPhiNguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "idNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lopHocs",
                columns: table => new
                {
                    lopHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lopHocMa = table.Column<int>(type: "int", nullable: false),
                    lopHocTen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nienKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    moTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tenKhoa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<bool>(type: "bit", nullable: false),
                    hocPhi = table.Column<double>(type: "float", nullable: false),
                    Lop = table.Column<int>(type: "int", nullable: false),
                    khoaHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lopHocs", x => x.lopHocId);
                    table.ForeignKey(
                        name: "FK_lopHocs_khoaHocs_khoaHocId",
                        column: x => x.khoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "khoaHocId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_lopHocs_NguoiDung_Lop",
                        column: x => x.Lop,
                        principalTable: "NguoiDung",
                        principalColumn: "idNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monHocs",
                columns: table => new
                {
                    monHocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    boMonHoc = table.Column<int>(type: "int", nullable: false),
                    monHoc = table.Column<int>(type: "int", nullable: false),
                    monHocMa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    monHocTen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    toBoMonId = table.Column<int>(type: "int", nullable: true),
                    khoaHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monHocs", x => x.monHocId);
                    table.ForeignKey(
                        name: "FK_monHocs_khoaHocs_khoaHocId",
                        column: x => x.khoaHocId,
                        principalTable: "khoaHocs",
                        principalColumn: "khoaHocId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_monHocs_toBoMons_toBoMonId",
                        column: x => x.toBoMonId,
                        principalTable: "toBoMons",
                        principalColumn: "toBoMonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diems",
                columns: table => new
                {
                    diemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diemMonHoc = table.Column<int>(type: "int", nullable: false),
                    tenKhoa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tenMonHoc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    soCotDiem = table.Column<int>(type: "int", nullable: false),
                    soCotDiemBatBuoc = table.Column<int>(type: "int", nullable: false),
                    loaiDiemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diems", x => x.diemId);
                    table.ForeignKey(
                        name: "FK_diems_loaiDiems_loaiDiemId",
                        column: x => x.loaiDiemId,
                        principalTable: "loaiDiems",
                        principalColumn: "loaiDiemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diems_monHocs_diemMonHoc",
                        column: x => x.diemMonHoc,
                        principalTable: "monHocs",
                        principalColumn: "monHocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thoiKhoaBieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleUser = table.Column<int>(type: "int", nullable: false),
                    ScheduleSubject = table.Column<int>(type: "int", nullable: false),
                    tenGiaoVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tenLop = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    monHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phongHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    gioHoc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngauBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thoiGian = table.Column<DateTime>(type: "datetime2", nullable: false),
                    monHocId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thoiKhoaBieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thoiKhoaBieus_monHocs_monHocId",
                        column: x => x.monHocId,
                        principalTable: "monHocs",
                        principalColumn: "monHocId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thoiKhoaBieus_NguoiDung_ScheduleUser",
                        column: x => x.ScheduleUser,
                        principalTable: "NguoiDung",
                        principalColumn: "idNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diems_diemMonHoc",
                table: "diems",
                column: "diemMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_diems_loaiDiemId",
                table: "diems",
                column: "loaiDiemId");

            migrationBuilder.CreateIndex(
                name: "IX_hocPhis_hocPhiNguoiDungId",
                table: "hocPhis",
                column: "hocPhiNguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_lopHocs_khoaHocId",
                table: "lopHocs",
                column: "khoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_lopHocs_Lop",
                table: "lopHocs",
                column: "Lop");

            migrationBuilder.CreateIndex(
                name: "IX_monHocs_khoaHocId",
                table: "monHocs",
                column: "khoaHocId");

            migrationBuilder.CreateIndex(
                name: "IX_monHocs_toBoMonId",
                table: "monHocs",
                column: "toBoMonId");

            migrationBuilder.CreateIndex(
                name: "IX_thoiKhoaBieus_monHocId",
                table: "thoiKhoaBieus",
                column: "monHocId");

            migrationBuilder.CreateIndex(
                name: "IX_thoiKhoaBieus_ScheduleUser",
                table: "thoiKhoaBieus",
                column: "ScheduleUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diems");

            migrationBuilder.DropTable(
                name: "hocPhis");

            migrationBuilder.DropTable(
                name: "lopHocs");

            migrationBuilder.DropTable(
                name: "thoiKhoaBieus");

            migrationBuilder.DropTable(
                name: "loaiDiems");

            migrationBuilder.DropTable(
                name: "monHocs");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "khoaHocs");

            migrationBuilder.DropTable(
                name: "toBoMons");
        }
    }
}
