using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NQLBaiTapLon010.Models
{
    public partial class LTQLDbContext : DbContext
    {
        public LTQLDbContext()
            : base("name=LTQLDbContext1")
        {
        }
        public virtual DbSet <Nhanvien> Nhanviens { get; set; }
        public virtual DbSet <Chucvu> Chucvus { get; set; }
        public virtual DbSet <Phongban> Phongbans { get; set; }
        public virtual DbSet <Luong> Luongs { get; set; }
        public virtual DbSet <Dangkytuyendung> Dangkys { get; set; }
        public virtual DbSet <NhanvienQL> NhanvienQLs { get; set; }
        public virtual DbSet <NhanvienTT> NhanvienTTs { get; set; }
        public virtual DbSet <Account> Accounts { get; set; }
        public virtual DbSet <Role> Roles { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
