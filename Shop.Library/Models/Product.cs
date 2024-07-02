using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop_CSharp.Models
{
    public class Product
    {

        public Product() { }

        public Product(string name, string description, decimal price, int quantity, double markdown=0, bool bogo=false)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = 0;
            Quantity = quantity;
            Markdown = markdown;
            Bogo = bogo;
        }


        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Markdown { get; set; }
        public bool Bogo { get; set; }

    }
}
