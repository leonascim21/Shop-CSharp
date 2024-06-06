using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_CSharp.Models
{
    public class Product
    {
        public Product(string name, string description, double price, int quantity)
        {
            Name = name;
            Description = description;
            Price = Math.Round(price, 2);
            Id = ++LastId;
            QuantityShelf = quantity;
            QuantityCart = 0;
        }


        internal string Name { get; set; }
        internal string Description { get; set; }
        internal double Price { get; set; }
        internal int Id { get; set; }
        internal int QuantityShelf { get; set; }
        internal int QuantityCart { get; set; }

        private static int LastId = 0;

    }
}
