﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSale.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public int AdminRank { get; set; }
    }
}