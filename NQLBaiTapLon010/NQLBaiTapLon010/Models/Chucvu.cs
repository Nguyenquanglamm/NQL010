using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("Chucvus")]
    public class Chucvu
    {
        [Key]
        [Display(Name ="Mã Chức Vụ")]
        public string IDchucvu { get; set; }
        [Display(Name ="Tên chức vụ")]
        public string Tenchucvu { get; set; }      
    }
}