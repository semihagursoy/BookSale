using BookSale.Models;
using BookSale.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookSale.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();

            return View(books);
        }

        public ActionResult Search(string search)
        {
            List<Book> book = db.Books.Where(b => b.BookName.StartsWith(search)).ToList();
            if(book.Count == 0)
            {
                book = db.Books.Where(b => b.CategoryName.StartsWith(search)).ToList();
            }else if(book.Count == 0)
            {
                book = db.Books.Where(b => b.BookAuthor.StartsWith(search)).ToList();
            }

            return View(book);
        }
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
         public ActionResult BuyProduct()
        {
            return View();
        }


    }
}
