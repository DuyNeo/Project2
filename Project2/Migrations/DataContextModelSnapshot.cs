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

            modelBuilder.Entity("Project2.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ClassCode")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CouresName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Describe")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("TuitionFee")
                        .HasColumnType("float");

                    b.Property<string>("Year")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ClassId");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("Project2.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Project2.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Project2.Models.PointType", b =>
                {
                    b.Property<int>("PointTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Coefficient")
                        .HasColumnType("int");

                    b.Property<string>("PointTypeName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PointTypeId");

                    b.ToTable("pointTypes");
                });

            modelBuilder.Entity("Project2.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Project2.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ClassRoom")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hours")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScheduleSubject")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subjects")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("subjectsSubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("usersUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("subjectsSubjectId");

                    b.HasIndex("usersUserId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("Project2.Models.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Diem")
                        .HasColumnType("real");

                    b.Property<int>("PointTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScoreId");

                    b.HasIndex("PointTypeId");

                    b.HasIndex("SubjectsId");

                    b.HasIndex("UserId");

                    b.ToTable("scores");
                });

            modelBuilder.Entity("Project2.Models.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SubjectName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SubjectId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("Project2.Models.Teachers", b =>
                {
                    b.Property<int>("TeachersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Concurrently")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CoreSubject")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FisrtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("TaxCode")
                        .HasColumnType("int");

                    b.Property<int>("TeachersCode")
                        .HasColumnType("int");

                    b.Property<string>("lop")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TeachersId");

                    b.HasIndex("RoleId");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("Project2.Models.Tuition", b =>
                {
                    b.Property<int>("TuitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<double>("Fee")
                        .HasColumnType("float");

                    b.Property<double>("FeeRate")
                        .HasColumnType("float");

                    b.Property<string>("Note")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TollType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Training")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TuitionUserId")
                        .HasColumnType("int");

                    b.Property<int?>("usersUserId")
                        .HasColumnType("int");

                    b.HasKey("TuitionId");

                    b.HasIndex("usersUserId");

                    b.ToTable("tuitions");
                });

            modelBuilder.Entity("Project2.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("ClassId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Project2.Models.Schedule", b =>
                {
                    b.HasOne("Project2.Models.Subjects", "subjects")
                        .WithMany()
                        .HasForeignKey("subjectsSubjectId");

                    b.HasOne("Project2.Models.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersUserId");

                    b.Navigation("subjects");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Project2.Models.Score", b =>
                {
                    b.HasOne("Project2.Models.PointType", "pointTypes")
                        .WithMany("scores")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.Subjects", "subjects")
                        .WithMany("scores")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.Users", "users")
                        .WithMany("scores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pointTypes");

                    b.Navigation("subjects");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Project2.Models.Subjects", b =>
                {
                    b.HasOne("Project2.Models.Course", "course")
                        .WithMany("subjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.Department", "department")
                        .WithMany("subjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Project2.Models.Teachers", b =>
                {
                    b.HasOne("Project2.Models.Role", "Role")
                        .WithMany("teachers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Project2.Models.Tuition", b =>
                {
                    b.HasOne("Project2.Models.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersUserId");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Project2.Models.Users", b =>
                {
                    b.HasOne("Project2.Models.Class", "Class")
                        .WithMany("users")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_Class_User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project2.Models.Role", "Role")
                        .WithMany("users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Project2.Models.Class", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("Project2.Models.Course", b =>
                {
                    b.Navigation("subjects");
                });

            modelBuilder.Entity("Project2.Models.Department", b =>
                {
                    b.Navigation("subjects");
                });

            modelBuilder.Entity("Project2.Models.PointType", b =>
                {
                    b.Navigation("scores");
                });

            modelBuilder.Entity("Project2.Models.Role", b =>
                {
                    b.Navigation("teachers");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Project2.Models.Subjects", b =>
                {
                    b.Navigation("scores");
                });

            modelBuilder.Entity("Project2.Models.Users", b =>
                {
                    b.Navigation("scores");
                });
#pragma warning restore 612, 618
        }
    }
}
