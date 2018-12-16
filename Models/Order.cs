using BookSale.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class Order
    {

        public int OrderId { get; set; }


        public string CustomerName { get; set; }

        public string BookName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CustomerId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int BookId { get; set; }

        public int quantity;

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}