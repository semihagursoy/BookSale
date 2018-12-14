using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookSale.Models;

namespace BookSale.Controllers.admin
{
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin adminAccount)
        {
            using (BookContext db = new BookContext())
            {
                var adminToLogin = db.Admins.Single(u => u.AdminName == adminAccount.AdminName && u.AdminPassword == adminAccount.AdminPassword);
                if (adminToLogin != null)
                {
                    Session["CustomerId"] = adminToLogin.AdminId.ToString();
                    Session["CustomerName"] = adminToLogin.AdminName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "User mail or the password is wrong.");
                }
            }
            return View("AdminLoggedin");
        }

        public ActionResult AdminLoggedIn()
        {
            if (Session["AdminId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

        }
    }
}