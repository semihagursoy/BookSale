using BookSale.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class InitialData
    {
        public static System.Collections.Generic.List<Admin> GetAdmins(BookContext context)
        {
            List<Admin> admins = new List<Admin>()
            {
                new Admin()
                {
                    AdminName = "semiha",
                    AdminPassword = "1111",
                    AdminRank = 1
                }
            };
            return admins;
        }
       
        
    }
}