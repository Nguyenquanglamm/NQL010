using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LTQL_17210500100.Models
{
    public partial class LTQLDb : DbContext
    {
        public LTQLDb()
            : base("name=LTQLDb")
        {
        }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NguyenQuangLam> NguyenQuangLams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public System.Data.Entity.DbSet<LTQL_17210500100.Models.Accounts> Accounts { get; set; }
    }
}
