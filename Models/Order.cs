using BookSale.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string BookName { get; set; }

        public int CustomerId { get; set; }
        public int BookId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}