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
            /*
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("AdminLogin");
            }
            */
            return View();
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
                            return RedirectToAction("AdminLoggedIn");
                        }
                        else
                        {
                            message = "User name or the password is wrong.";
                        }

                    }
                    else if (user == null)
                    {
                        message = "Invalid credential provided.";
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User name and the password are required.");
                }
            }
            ViewBag.Message = message;
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

        [NonAction]
        public bool IsAdminExist(string adminName)
        {
            using(BookContext db = new BookContext())
            {
                var adminNameExist = db.Admins.Where(e => e.AdminName == adminName).FirstOrDefault();
                if (adminNameExist.AdminName.ToString() != null)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}