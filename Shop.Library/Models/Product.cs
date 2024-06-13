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
            Id = 0;
            Quantity = quantity;
        }


        internal string? Name { get; set; }
        internal string? Description { get; set; }
        internal double Price { get; set; }
        internal int Id { get; set; }
        internal int Quantity { get; set; }

    }
}
