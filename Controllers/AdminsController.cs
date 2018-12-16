using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookSale.Models;

namespace BookSale.Controllers
{
    public class AdminsController : Controller
    {
        private BookContext db = new BookContext();


        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            else
            {
                return View(db.Admins.ToList());
            }
            
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdminName,AdminPassword,AdminRank")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,AdminName,AdminPassword,AdminRank")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(AdminLogin adminAccount)
        {
            string message = "";
            using (BookContext db = new BookContext())
            {
                if (ModelState.IsValid)
                {
                    Admin user = db.Admins.SingleOrDefault(u => u.AdminName == adminAccount.AdminName && u.AdminPassword == adminAccount.AdminPassword);
                    if (user != null)
                    {
                        if (string.Compare(adminAccount.AdminPassword, user.AdminPassword) == 0)
                        {
                            Session["AdminId"] = user.AdminId.ToString();
                            Session["AdminName"] = user.AdminName.ToString();
                            message = user.AdminName + " is now logging in.";
                            return RedirectToAction("Index" , "Admins");
                        }
                    }
                }
                return View();
            }

        }

        public ActionResult List()
        {
            
            return View(db.Admins.ToList());
        }
    }
}
