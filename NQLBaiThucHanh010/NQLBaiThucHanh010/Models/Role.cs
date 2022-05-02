using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiThucHanh010.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "ID")]
        public string RoleID { get; set; }
        [Display(Name = "Đối Tượng")]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}