using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class CustomerOrder
    {
        public int CustomerId { get; set; }

        public int BookId { get; set; }

        public string CustomerName { get; set; }


        public int quantity { get; set; } 
    }
}