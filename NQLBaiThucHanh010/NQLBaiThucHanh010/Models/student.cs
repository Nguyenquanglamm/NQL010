using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiThucHanh010.Models
{
    [Table("Students")]
    public class student
    {
        [Key]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
    }
}