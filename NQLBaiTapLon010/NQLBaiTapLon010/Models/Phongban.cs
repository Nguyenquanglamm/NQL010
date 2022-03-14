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
        public string IDphongban { get; set; }
        public string Tenphongban { get; set; }
    }
}