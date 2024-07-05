using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Services
{
    public class InventoryServiceProxy
    {
        private static InventoryServiceProxy? instance;
        private static object instanceLock = new object();

        private List<Product> products;

        public ReadOnlyCollection<Product> Products
        {
            get
            {
                return products.AsReadOnly();
            }
        }
        
        public double TaxRate {  get; set; }
        private int NextId
        {
            get
            {
                if (!products.Any())
                {
                    return 1;
                }

                return products.Select(p => p.Id).Max() + 1;
            }
        }

        public Product AddOrUpdate(Product p)
        {
            bool isAdd = false;
            if (p.Id == 0)
            {
                isAdd = true;
                p.Id = NextId;
            }

            if (isAdd)
            {
                products.Add(p);
            }

            else
            {
                Product ProductToEdit = Current.Products.First(prod => prod.Id == p.Id);
                ProductToEdit = p;
            }

            return p;
        }

        public void Remove(Product p)
        {
            products.Remove(p);
        }

        private InventoryServiceProxy()
        {
            products = new List<Product>{
                new Product{Id = 1, Name = "Apples", Price=1.75M, Quantity=25, Description="Red apples"},
                new Product{Id = 2, Name = "Bananas", Price=0.99M, Quantity=30, Description="Yellow bananas"},
                new Product{Id = 3, Name = "Oranges", Price=1.50M, Quantity=60, Description="Orange oranges"},
                new Product{Id = 4, Name = "Milk", Price=2.99M, Quantity=45, Description="1 gallon of milk"},
                new Product{Id = 5, Name = "Bread", Price=2.50M, Quantity=150, Description="bread loaf"},
                new Product{Id = 6, Name = "Eggs", Price=3.99M, Quantity=180, Description="One dozen eggs"},
                new Product{Id = 7, Name = "Cheese", Price=5.00M, Quantity=80, Description="Cheddar cheese"},
                new Product{Id = 8, Name = "Butter", Price=4.50M, Quantity=60, Description="Salted butter"},
                new Product{Id = 9, Name = "Chicken Breast", Price=7.99M, Quantity=90, Description="Chicken breast"},
                new Product{Id = 10, Name = "Ground Beef", Price=6.99M, Quantity=70, Description="1 lb of ground beef"},
            };
            TaxRate = 0.07;
        }

        public static InventoryServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InventoryServiceProxy();
                    }
                }
                return instance;
            }
        }





    }
}
