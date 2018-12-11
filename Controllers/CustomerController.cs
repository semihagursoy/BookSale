using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSale.Models;

namespace BookSale.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer CustomerAccount)
        {
            if (ModelState.IsValid)
            {
                using (BookContext db = new BookContext())
                {
                    db.Customers.Add(CustomerAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = CustomerAccount.CustomerName + " successfully registered." ;
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customerAccount)
        {
            using(BookContext db = new BookContext())
            {
                var user = db.Customers.Single(u => u.CustomerMail == customerAccount.CustomerMail && u.CustomerPassword == customerAccount.CustomerPassword);
                if(user != null)
                {
                    Session["CustomerId"] = user.CustomerId.ToString();
                    Session["CustomerName"] = user.CustomerName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "User mail or the password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["CustomerId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
    }
}