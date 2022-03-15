using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("Phongbans")]
    public class Phongban
    {
        [Key]
        [Display(Name ="Mã phòng ban")]
        public string IDphongban { get; set; }

        [Display(Name ="Tên phòng ban")]
        public string Tenphongban { get; set; }

        [Display(Name ="Số trực phòng ban")]
        public string Sdtphongban { get; set; }

        public ICollection<Nhanvien> Nhanviens { get; set; }
    }
}