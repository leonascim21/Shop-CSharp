using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(string name, int id)
        {
            Contents = new List<Product>();
            Id = id;
            Name = name;
        }

        public ShoppingCart()
        {
            Contents = new List<Product>();
            Id = 0;
            Name = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Contents { get; set; }

    }
}
