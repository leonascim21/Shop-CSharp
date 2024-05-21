using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_CSharp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<Product>();
        }

        public void AddToCart(Product product, int quantity)
        {
            product.QuantityCart += quantity;
            product.QuantityShelf -= quantity;
            Items.Add(product);
        }

        public void RemoveFromCart(int ID, int quantity)
        {

            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    if (quantity > item.QuantityCart) { quantity = item.QuantityCart; }
                    item.QuantityCart -= quantity;
                    item.QuantityShelf += quantity;
                    if (item.QuantityCart == 0) { Items.Remove(item); }
                }
            }
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (Product product in Items)
            { total += product.Price * product.QuantityCart; }

            return total;
        }

        public void PrintCart()
        {
            foreach (Product item in Items)
            {
                Console.WriteLine($"[ID: {item.Id}]     Name: {item.Name}     Price: ${item.Price}     Quantity: {item.QuantityCart}");
            }
        }


        private List<Product> Items;
    }
}
