using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTQL_17210500100.Models
{
    public class Accounts
    {
        [Key]
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}