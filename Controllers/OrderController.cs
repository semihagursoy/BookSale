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
    public class OrderController : Controller
    {
        private BookContext db = new BookContext();

        
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Book).Include(o => o.Customer);
            
            if(Session["CustomerId"] != null)
            {
                orders = db.Orders.Where(o => o.CustomerId == Convert.ToInt32(Session["CustomerId"]));
            }
            return View(orders.ToList());
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i<cart.Count; i++)
            {
                if(cart[i].Book.BookId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult OrderNow(int id)
        {
            if(Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Books.Find(id) , 1 ));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if(index == -1)
                {
                    cart.Add(new Item(db.Books.Find(id), 1));
                }
                else
                {
                    
                        cart[index].Book.BookQuantity++;
      
                }
                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ActionResult BuyProducts(List<Item> cart)
        {
            if(cart != null)
            {
                foreach(var item in cart)
                {
                    Order order = new Order();
                    order.BookId = item.Book.BookId;
                    order.Count = item.Quantity;
                    order.CustomerId = Convert.ToInt32(Session["CustomerId"].ToString());
                    order.CustomerName = Session["CustomerName"].ToString();
                    order.OrderAddress = Session["CustomerAddress"].ToString();
                    order.Total = (decimal)item.Book.BookPrice;
                    order.OrderDate = DateTime.Now;

                    db.Orders.Add(order);
                    db.SaveChanges();



                    Create(order);

                }
            }
            return View();
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View("ViewOrders");
        }

        
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,BookId,Count,CustomerId,CustomerName,OrderAddress,Total,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookName", order.BookId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

       

    }
}
