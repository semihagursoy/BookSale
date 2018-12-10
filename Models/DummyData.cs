using BookSale.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class DummyData
    {
        public static System.Collections.Generic.List<Book> GetBooks(BookContext context)
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                  BookName = "16.50 Treni",
                  BookAuthor  = "Agatha Cristie",
                  BookBinding = "Altın Kitap",
                  BookDescription = "bla bla",
                  BookPrice = 30.00,
                  BookStock = 300,
                  CategoryName = context.Categories.Find("Polisiye").CategoryName
                
                }
            };
            return books;

        }
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Polisiye"
                }
            };
            return categories;
        }
        
    }
}