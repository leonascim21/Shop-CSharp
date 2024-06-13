using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Models
{
    internal class ShoppingCart
    {
        int Id { get; set; }
        public List<Product>? Contents { get; set; }
    }
}
