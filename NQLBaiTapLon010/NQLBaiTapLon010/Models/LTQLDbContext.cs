using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NQLBaiTapLon010.Models
{
    public partial class LTQLDbContext : DbContext
    {
        public LTQLDbContext()
            : base("name=LTQLDbContext")
        {
        }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
