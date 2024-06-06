using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    item.Price = Math.Round(price,2);
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


        public void PrintCatalog()
        {
            foreach (Product item in Items)
            {
                Console.Write(
                    $"___________________________________________\n" +
                    $"[ID: {item.Id, -4}]     Name: {item.Name, -20}     Price: ${item.Price, -10}     Quantity: {item.QuantityShelf, -5}\n" +
                    $"Description: {item.Description}\n");
            }
        }

        //RETURNS TRUE IF STRING S CONTAINS THE ID OF AN EXISTING PRODUCT
        public bool ValidID(string s)
        {
            Program program = new Program();
            int Id = 0;

            bool isInt = program.checkValidInt(s);
            if(isInt) { Id = int.Parse(s); }
            else { return false; }

            foreach (Product item in Items)
            {
                if (Id == item.Id)
                    return true;
            }

            return false;
        }

        public bool ValidQuantity(int ID, string quantityString)
        {
            Program program = new Program();
            
            if (!program.checkValidInt(quantityString)) 
            { return false; }

            int quantity = int.Parse(quantityString);

            foreach (Product item in Items)
            {
                if(ID == item.Id)
                {
                    if (quantity <= item.QuantityShelf) { return true; } else {  return false; }
                }
            }

            return false;
        }

        internal List<Product> Items;
    }
}
