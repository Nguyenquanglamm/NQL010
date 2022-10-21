using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL_17210500100.Models
{
    [Table("NguyenQuanglams")]
    public class NguyenQuangLam
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}