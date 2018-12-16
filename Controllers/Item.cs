using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookSale.Models;
using BookSale.Models.Books;

namespace BookSale.Controllers
{
    public class Item
    {
        private Book book = new Book();
        private int quantity;

        public Item()
        {}

        public Item(Book book, int quantity)
        {
            this.Book = book;
            this.Quantity = quantity;
        }

        public Book Book { get => book; set => book = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}