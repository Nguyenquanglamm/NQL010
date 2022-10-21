using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_17210500100.Models
{
    [Table("NhaCungCaps")]
    public class NhaCungCap
    {
        [Key]
        [Display(Name ="Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }
        [Display(Name ="Tên nhà cung cấp")]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string TenNhaCungCap { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}