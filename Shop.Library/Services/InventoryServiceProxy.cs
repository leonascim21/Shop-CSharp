using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shop.Library.Utilities;

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
        
        public decimal TaxRate {  get; set; }
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
            TaxRate = 0.07m;

            var response = new WebRequestHandler().Get("/Inventory").Result;
            products = JsonConvert.DeserializeObject<List<Product>>(response);
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
