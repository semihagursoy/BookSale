using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class CustomerLogin
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string CustomerMail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
    }
}