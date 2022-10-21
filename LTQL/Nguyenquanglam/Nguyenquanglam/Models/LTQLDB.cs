using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Nguyenquanglam.Models
{
    public partial class LTQLDB : DbContext
    {
        public LTQLDB()
            : base("name=LTQLDB")
        {
        }
        public virtual DbSet<TinhThanh> TinhThanhs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public System.Data.Entity.DbSet<Nguyenquanglam.Models.Accounts> Accounts { get; set; }
    }
}
