using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nguyenquanglam.Models
{
    [Table("NhanViens")]
    public class Nhanvien
    {
        [Key]
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int MaTinhThanh { get; set; }
        [ForeignKey("MaTinhThanh")]
        public virtual TinhThanh Tinhthanhs { get; set; }
    }
}