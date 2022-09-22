﻿
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
        public DbSet<NguoiDung> nguoiDungs { get; set; }
       
        public DbSet<LopHoc> lopHocs { get; set; }
        public DbSet<Diem> diems { get; set; }
        public DbSet<LoaiDiem> loaiDiems { get; set; }

        public DbSet<KhoaHoc> khoaHocs { get; set; }
        public DbSet<ToBoMon> toBoMons { get; set; }
        public DbSet<ThoiKhoaBieu> thoiKhoaBieus { get; set; }

        public DbSet<HocPhi> hocPhis { get; set; }

        public DbSet<MonHoc> monHocs { get; set; }
        public DbSet<GiangVien> giangViens { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
