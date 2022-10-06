
using Microsoft.EntityFrameworkCore;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(u => u.HasOne(x => x.Class)
            .WithMany(x => x.users)
            .HasForeignKey(x=>x.ClassId)
            .HasConstraintName("FK_Class_User_id"));

            modelBuilder.Entity<Users>(a => a.HasOne(n => n.Role)
           .WithMany(x => x.users)
           .HasForeignKey(v => v.RoleId));
           modelBuilder.Entity<Teachers>(a => a.HasOne(n => n.Role)
           .WithMany(x => x.teachers)
           .HasForeignKey(v => v.RoleId)
           );

            modelBuilder.Entity<Subjects>(a => a.HasOne(n => n.department)
          .WithMany(x => x.subjects)
          .HasForeignKey(v => v.DepartmentId)
          );
            modelBuilder.Entity<Subjects>(a => a.HasOne(n => n.course)
          .WithMany(x => x.subjects)
          .HasForeignKey(v => v.CourseId)
          );

            modelBuilder.Entity<Score>(a => a.HasOne(n => n.pointTypes)
        .WithMany(x => x.scores)
        .HasForeignKey(v => v.PointTypeId)
        );
            modelBuilder.Entity<Score>(a => a.HasOne(n => n.subjects)
        .WithMany(x => x.scores)
        .HasForeignKey(v => v.SubjectsId)
        );
            modelBuilder.Entity<Score>(a => a.HasOne(n => n.users)
       .WithMany(x => x.scores)
       .HasForeignKey(v => v.UserId)
       );
        }
        public DbSet<Users> users { get; set; }
       
        public DbSet<Class> classes { get; set; }
        public DbSet<Score> scores { get; set; }
        public DbSet<PointType> pointTypes { get; set; }

        public DbSet<Course> courses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Schedule> schedules { get; set; }

        public DbSet<Tuition> tuitions { get; set; }

        public DbSet<Subjects> subjects { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
