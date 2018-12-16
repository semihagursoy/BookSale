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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Admin name is required.")]
        public string AdminName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

        public int AdminRank { get; set; }
    }
}