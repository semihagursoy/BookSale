using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookSale.Models;
using BookSale.Models.Books;

namespace BookSale.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Category);
            return View(books.ToList());
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

        
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,BookAuthor,BookBinding,BookDescription,BookPrice,BookStock,CategoryName,BookImage")] Book book , HttpPostedFileBase UploadImage)
        {

            if (ModelState.IsValid)
            {
                if(UploadImage != null)
                {
                    if(UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || 
                        UploadImage.ContentType == "image/jpeg" || UploadImage.ContentType == "image/bmp")
                        {
                            UploadImage.SaveAs(Server.MapPath("/") + "/Content/" + UploadImage.FileName);
                            book.BookImage = UploadImage.FileName;
                        }
                }
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName", book.CategoryName);
            return View(book);
        }

        
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName", book.CategoryName);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,BookAuthor,BookBinding,BookDescription,BookPrice,BookStock,CategoryName")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryName = new SelectList(db.Categories, "CategoryName", "CategoryName", book.CategoryName);
            return View(book);
        }


        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult List()
        {
            List<Book> books = db.Books.ToList();
            return View(books);
        }
    }
}
