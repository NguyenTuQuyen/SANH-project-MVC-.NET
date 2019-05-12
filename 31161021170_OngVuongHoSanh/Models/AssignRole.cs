using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class AssignRole
    {
        [Key]
        public string userName { get; set; }
        public string roleName { get; set; }

    }
}
