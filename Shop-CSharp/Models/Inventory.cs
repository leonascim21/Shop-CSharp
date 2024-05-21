using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_CSharp.Models
{
    public class Inventory
    {
        public Inventory()
        {
            Items = new List<Product>();
        }

        public void AddItem(string name, string description, double price, int quantity)
        {
            Items.Add(new Product(name, description, price, quantity));
        }

        public bool RemoveItem(int ID)
        {
            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    Items.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public void EditName(int ID, string name)
        {
            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    item.Name = name;
                }
            }
        }
        public void EditDescription(int ID, string description)
        {
            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    item.Description = description;
                }
            }
        }
        public void EditPrice(int ID, double price)
        {
            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    item.Price = price;
                }
            }
        }
        public void EditQuantity(int ID, int quantity)
        {
            foreach (Product item in Items)
            {
                if (ID == item.Id)
                {
                    item.QuantityShelf = quantity;
                }
            }
        }

        public void Print()
        {
            foreach (Product item in Items)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintNames()
        {
            foreach (Product item in Items)
            {
                Console.WriteLine($"[{item.Id}] {item.Name}");
            }
        }

        public void PrintCatalog()
        {
            foreach (Product item in Items)
            {
                Console.Write(
                    $"___________________________________________\n" +
                    $"[ID: {item.Id}]     Name: {item.Name}     Price: ${item.Price}     Quantity: {item.QuantityShelf}\n" +
                    $"Description: {item.Description}\n");
            }
        }

        private List<Product> Items;
    }
}
