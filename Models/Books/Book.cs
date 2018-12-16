using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models.Books
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookBinding { get; set; }
        public string BookDescription { get; set; }
        public double BookPrice { get; set; }
        public int BookStock { get; set; }
        //public HttpPostedFileBase BookImage { get; set; }

        public int BookQuantity { get; set; }
        public string BookImage { get; set; }

        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }
 
    }
}