using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            bool status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                //email already exists 
                var customerExists = IsCustomerExist(CustomerAccount.CustomerMail.ToString());
                if (customerExists)
                {
                    ModelState.AddModelError("EmailExist" , "This email is already in use.");
                    return View(CustomerAccount);
                }

                using (BookContext db = new BookContext())
                {
                    db.Customers.Add(CustomerAccount);
                    db.SaveChanges();
                }
                
                message = CustomerAccount.CustomerName + " successfully registered." ;
                ModelState.Clear();
                status = true;
                
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = status;
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin customerAccount)
        {
            string message = "";
            using(BookContext db = new BookContext())
            {

                if(ModelState.IsValid)
                {
                    Customer user = db.Customers.SingleOrDefault(u => u.CustomerMail == customerAccount.CustomerMail && u.CustomerPassword == customerAccount.CustomerPassword);
                    if (user != null)
                    {
                        if (string.Compare(customerAccount.CustomerPassword, user.CustomerPassword) == 0)
                        {
                            Session["CustomerId"] = user.CustomerId.ToString();
                            Session["CustomerName"] = user.CustomerName.ToString();
                            message = user.CustomerName + " is now logging in.";
                            return RedirectToAction("CustomerLoggedIn");
                        }
                        else
                        {
                            message = "User mail or the password is wrong.";
                        }

                    }
                    else if( user == null)
                    {
                        message = "Invalid credential provided.";
                        //ModelState.AddModelError("", "User mail or the password is wrong.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User mail and the password are required.");
                }
            }
            ViewBag.Message = message;
            
            return View();
        }

        public ActionResult CustomerLoggedIn(Customer customer)
        {
            if(Session["CustomerId"] != null)
            {
                // , new { @id = Session["CustomerId"] } aşağıdaki satırdaki koda ekle

                return RedirectToAction("Index" , "");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        
        public ActionResult CustomerLogout()
        {
            Session.Clear();
            return RedirectToAction("Login" , "Customer" );
        }
        
        [NonAction]
        public bool IsCustomerExist(string CustomerMail)
        {
            using (BookContext db = new BookContext())
            {
                var CustomerMailExist = db.Customers.Where(e => e.CustomerMail == CustomerMail).FirstOrDefault();
                if (CustomerMailExist != null && CustomerMailExist.CustomerMail.ToString() != null)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}