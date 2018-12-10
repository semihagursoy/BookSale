using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSale.Models.Books
{
    public class Category
    {
        [Key]
        [MaxLength(30)]
        public string CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}