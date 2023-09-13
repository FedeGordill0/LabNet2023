using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_3_EF.WebAPI.Models
{
    public class CategoryView
    {
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(15)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}