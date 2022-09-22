﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project2.Models;

namespace Project2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project2.Models.Diem", b =>
                {
                    b.Property<int>("diemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("diemMonHoc")
                        .HasColumnType("int");

                    b.Property<int?>("loaiDiemId")
                        .HasColumnType("int");

                    b.Property<int>("soCotDiem")
                        .HasColumnType("int");

                    b.Property<int>("soCotDiemBatBuoc")
                        .HasColumnType("int");

                    b.Property<string>("tenKhoa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("tenMonHoc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("diemId");

                    b.HasIndex("diemMonHoc");

                    b.HasIndex("loaiDiemId");

                    b.ToTable("diems");
                });

            modelBuilder.Entity("Project2.Models.GiangVien", b =>
                {
                    b.Property<int>("gvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hinh")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lop")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diaChi")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("gioiTinh")
                        .HasColumnType("int");

                    b.Property<int?>("lopHocId")
                        .HasColumnType("int");

                    b.Property<int>("maGV")
                        .HasColumnType("int");

                    b.Property<int>("maSoThue")
                        .HasColumnType("int");

                    b.Property<string>("matKhau")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("monHocChinh")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("monKienNhiem")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("soDienThoai")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("gvId");

                    b.HasIndex("lopHocId");

                    b.HasIndex("roleId");

                    b.ToTable("giangViens");
                });

            modelBuilder.Entity("Project2.Models.HocPhi", b =>
                {
                    b.Property<int>("hocPhiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ghiChu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("giamGia")
                        .HasColumnType("int");

                    b.Property<int>("hocPhiNguoiDungId")
                        .HasColumnType("int");

                    b.Property<string>("khoaDaoTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("loaiThuPhi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lopHoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("mucThuPhi")
                        .HasColumnType("float");

                    b.Property<double>("thuPhi")
                        .HasColumnType("float");

                    b.Property<string>("trangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hocPhiId");

                    b.HasIndex("hocPhiNguoiDungId");

                    b.ToTable("hocPhis");
                });

            modelBuilder.Entity("Project2.Models.KhoaHoc", b =>
                {
                    b.Property<int>("khoaHocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("khoaHocMa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("khoaHocTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ngayKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("khoaHocId");

                    b.ToTable("khoaHocs");
                });

            modelBuilder.Entity("Project2.Models.LoaiDiem", b =>
                {
                    b.Property<int>("loaiDiemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HeSo")
                        .HasColumnType("int");

                    b.Property<string>("loaiDiemTen")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("loaiDiemId");

                    b.ToTable("loaiDiems");
                });

            modelBuilder.Entity("Project2.Models.LopHoc", b =>
                {
                    b.Property<int>("lopHocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lop")
                        .HasColumnType("int");

                    b.Property<double>("hocPhi")
                        .HasColumnType("float");

                    b.Property<int?>("khoaHocId")
                        .HasColumnType("int");

                    b.Property<int>("lopHocMa")
                        .HasColumnType("int");

                    b.Property<string>("lopHocTen")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("moTa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nienKhoa")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("soLuong")
                        .HasColumnType("int");

                    b.Property<string>("tenKhoa")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("trangThai")
                        .HasColumnType("bit");

                    b.HasKey("lopHocId");

                    b.HasIndex("Lop");

                    b.HasIndex("khoaHocId");

                    b.ToTable("lopHocs");
                });

            modelBuilder.Entity("Project2.Models.MonHoc", b =>
                {
                    b.Property<int>("monHocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("boMonHoc")
                        .HasColumnType("int");

                    b.Property<int?>("khoaHocId")
                        .HasColumnType("int");

                    b.Property<int>("monHoc")
                        .HasColumnType("int");

                    b.Property<string>("monHocMa")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("monHocTen")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("toBoMonId")
                        .HasColumnType("int");

                    b.HasKey("monHocId");

                    b.HasIndex("khoaHocId");

                    b.HasIndex("toBoMonId");

                    b.ToTable("monHocs");
                });

            modelBuilder.Entity("Project2.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Project2.Models.ThoiKhoaBieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ScheduleSubject")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("Thu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("gioHoc")
                        .HasColumnType("datetime2");

                    b.Property<string>("monHoc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("monHocId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ngauBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ngayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("phongHoc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("tenGiaoVien")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("tenLop")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("thoiGian")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleUser");

                    b.HasIndex("monHocId");

                    b.ToTable("thoiKhoaBieus");
                });

            modelBuilder.Entity("Project2.Models.ToBoMon", b =>
                {
                    b.Property<int>("toBoMonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("toBoMonTen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("toBoMonId");

                    b.ToTable("toBoMons");
                });

            modelBuilder.Entity("QLHS.Models.NguoiDung", b =>
                {
                    b.Property<int>("idNguoiDung")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("chucDanh")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("gioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("matKhau")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("tenDaydu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("tenNguoiDung")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idNguoiDung");

                    b.ToTable("nguoiDungs");
                });

            modelBuilder.Entity("Project2.Models.Diem", b =>
                {
                    b.HasOne("Project2.Models.MonHoc", "monHoc")
                        .WithMany()
                        .HasForeignKey("diemMonHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.LoaiDiem", "loaiDiem")
                        .WithMany()
                        .HasForeignKey("loaiDiemId");

                    b.Navigation("loaiDiem");

                    b.Navigation("monHoc");
                });

            modelBuilder.Entity("Project2.Models.GiangVien", b =>
                {
                    b.HasOne("Project2.Models.LopHoc", "lopHoc")
                        .WithMany()
                        .HasForeignKey("lopHocId");

                    b.HasOne("Project2.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("roleId");

                    b.Navigation("lopHoc");

                    b.Navigation("role");
                });

            modelBuilder.Entity("Project2.Models.HocPhi", b =>
                {
                    b.HasOne("QLHS.Models.NguoiDung", "nguoiDung")
                        .WithMany()
                        .HasForeignKey("hocPhiNguoiDungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("nguoiDung");
                });

            modelBuilder.Entity("Project2.Models.LopHoc", b =>
                {
                    b.HasOne("QLHS.Models.NguoiDung", "nguoiDung")
                        .WithMany()
                        .HasForeignKey("Lop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.KhoaHoc", "khoaHoc")
                        .WithMany()
                        .HasForeignKey("khoaHocId");

                    b.Navigation("khoaHoc");

                    b.Navigation("nguoiDung");
                });

            modelBuilder.Entity("Project2.Models.MonHoc", b =>
                {
                    b.HasOne("Project2.Models.KhoaHoc", "khoaHoc")
                        .WithMany()
                        .HasForeignKey("khoaHocId");

                    b.HasOne("Project2.Models.ToBoMon", "toBoMon")
                        .WithMany()
                        .HasForeignKey("toBoMonId");

                    b.Navigation("khoaHoc");

                    b.Navigation("toBoMon");
                });

            modelBuilder.Entity("Project2.Models.ThoiKhoaBieu", b =>
                {
                    b.HasOne("QLHS.Models.NguoiDung", "nguoiDung")
                        .WithMany()
                        .HasForeignKey("ScheduleUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.MonHoc", "MonHoc")
                        .WithMany()
                        .HasForeignKey("monHocId");

                    b.Navigation("MonHoc");

                    b.Navigation("nguoiDung");
                });
#pragma warning restore 612, 618
        }
    }
}
