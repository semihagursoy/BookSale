using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "User Address is Required")]
        public string CustomerAddress { get; set; }

        [MaxLength(11)]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string CustomerMail { get; set; }

        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

        public string 
    }
}