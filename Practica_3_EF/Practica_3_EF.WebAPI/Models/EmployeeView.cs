using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_3_EF.WebAPI.Models
{
    public class EmployeeView
    {
        public int EmployeeID { get; set; }


        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(15)]
        public string Country { get; set; }
    }
}