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

        public void AddToCart(int ID, int quantity, Inventory inventory)
        {

            foreach(Product item in Items)
            {
                if (ID == item.Id)
                {
                    item.QuantityCart += quantity;
                    item.QuantityShelf -= quantity;
                    return;
                }
            }



            foreach (Product item in inventory.Items)
            {
                if (ID == item.Id)
                {
                    item.QuantityCart += quantity;
                    item.QuantityShelf -= quantity;
                    Items.Add(item);
                }
            }

        }

        public void RemoveFromCart(int ID, int quantity)
        {
            Product? deletionObject = null;

            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    if (quantity > item.QuantityCart) { quantity = item.QuantityCart; }
                    item.QuantityCart -= quantity;
                    item.QuantityShelf += quantity;
                    if (item.QuantityCart == 0) { deletionObject = item; }
                }
                
            }
            if ((deletionObject != null) && deletionObject.QuantityCart == 0) { Items.Remove(deletionObject); }
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
                Console.WriteLine($"[ID: {item.Id, -4}]     Name: {item.Name,-20}     Price: ${item.Price,-10}     Quantity: {item.QuantityCart,-5}");
            }
        }

        public bool ValidQuantity(int ID, string quantityString)
        {
            Program program = new Program();

            if (!program.checkValidInt(quantityString))
            { return false; }

            int quantity = int.Parse(quantityString);

            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    if (quantity <= item.QuantityCart) { return true; } else { return false; }
                }
            }

            return false;
        }

        public bool ValidID(string s)
        {
            Program program = new Program();
            int Id = 0;

            bool isInt = program.checkValidInt(s);
            if (isInt) { Id = int.Parse(s); }
            else { return false; }

            foreach (Product item in Items)
            {
                if (Id == item.Id)
                    return true;
            }

            return false;
        }



        private List<Product> Items;
    }
}
