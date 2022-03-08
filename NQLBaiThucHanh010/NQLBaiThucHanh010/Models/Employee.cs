using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiThucHanh010.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}