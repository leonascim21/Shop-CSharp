﻿using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Models
{
    public class ShoppingCart
    {
        public List<Product>? Contents { get; set; }


        public ShoppingCart()
        {
            Contents = new List<Product>()
            {
                new Product{Id = 1, Name = "Apples", Price=1.75M, Quantity=25, Description="Red apples"}
            };
        }

    }
}
