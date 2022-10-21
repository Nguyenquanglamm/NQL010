using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_17210500100.Models
{
    [Table("Sanphams")]
    public class SanPham
    {
        [Key]
        [Display(Name ="Mã sản phẩm")]
        public string MaSanpham { get; set; }
        public string TenSanpham { get; set; }
        public int MaSanPham { get; set; }
        
    }
}