using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Admin name is required.")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string AdminPassword { get; set; }

        public int AdminRank { get; set; }
    }
}