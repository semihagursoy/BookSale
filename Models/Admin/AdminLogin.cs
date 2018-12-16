using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class AdminLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Admin name is required.")]
        public string AdminName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string AdminPassword { get; set; }

    }
}