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
        [Key]
        public int OrderId { get; set; }


        [Required(AllowEmptyStrings = false)]
        public int BookId { get; set; }
        public int Count { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string OrderAddress { get; set; }
        
        
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}