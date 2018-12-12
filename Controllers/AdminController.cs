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
        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("AdminLogin");
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            using (BookContext db = new BookContext())
            {
                var adminToLogin = db.Admins.Single(a => a.AdminName == admin.AdminName && a.AdminPassword == admin.AdminPassword);
                if(adminToLogin != null)
                {
                    Session["AdminName"] = adminToLogin.AdminName.ToString();
                    return RedirectToAction("LoggedIn");
                }
            }
            return View();
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