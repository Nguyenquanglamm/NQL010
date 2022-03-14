using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("NhanViens")]
    public class Nhanvien
    {
        [Key]
        public string IDnhanvien { get; set; }
        public string Tennhanvien { get; set; }
        public string Ngaysinhnhanvien { get; set; }
        public string SDTnhanvien { get; set; }
        public string Gioitinhnhanvien { get; set; }
        public string Diachinhanvien { get; set; }
        public string CCCDnhanvien { get; set; }
        public DateTime ngayvao { get; set; }
    }
}