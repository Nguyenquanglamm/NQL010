using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nguyenquanglam.Models
{
    [Table("Tinhthanhs")]
    public class TinhThanh
    {
        [Key]
        public int MaTinhThanh { get; set; }
        [Display(Name = "Tên tỉnh thành")]
        [StringLength(50)]
        public string TenTinhThanh { get; set; }

        public ICollection <Nhanvien> Nhanviens { get; set; }
    }
}