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
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        [MaxLength(11)]
        public string CustomerPhone { get; set; }

        [EmailAddress]
        public string CustomerMail { get; set; }

        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
    }
}