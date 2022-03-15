using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("Luongs")]
    public class Luong
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nhân Viên")]
        public String IDNhanVien { get; set; }
        public virtual Nhanvien Nhanviens { get; set; }


        [Display(Name = "Tháng")]
        public DateTime Thang { get; set; }

        [Display(Name = "Lương Ngày")]
        public float LuongNgay { get; set; }

        [Display(Name = "Số ngày đi làm")]
        public float NgayCong { get; set; }

        [Display(Name = "Tạm Ứng")]
        public float TamUng { get; set; }
    }
}