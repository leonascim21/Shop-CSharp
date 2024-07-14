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

        public async Task<Product> AddOrUpdate(Product p)
        {
            await new WebRequestHandler().Post("/Inventory", p);
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

        public void GetProducts()
        {
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
