using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NQLBaiThucHanh010.Models
{
    public partial class LtqlDbContext : DbContext
    {
        public LtqlDbContext()
            : base("name=LtqlDbContext")
        {
        }
        public virtual DbSet<student> Students { get; set; }
        public virtual DbSet<person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
