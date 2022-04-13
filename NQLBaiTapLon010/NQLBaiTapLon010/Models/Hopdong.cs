using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("Hopdongs")]
    public class Hopdong
    {
        [Key]
        [Display(Name ="Mã hợp đồng")]
        public string ID { get; set; }

        public string IDnhanvien { get; set; }
        [ForeignKey("IDnhanvien")]
        public virtual Nhanvien Nhanviens { get; set; }

        [Display(Name = "Ngày ký hết hợp đồng")]
        [Required(ErrorMessage = "Ngày ký kết hợp đồng không được để trống !")]
        public DateTime Ngaykyket { get; set; }

        [Display(Name = "Thời hạn của hợp đồng")]
        [Required(ErrorMessage = "Thời hanjcuar hợp đồng không được để trống !")]
        public string Thoihanhopdong { get; set; } 
    }
}