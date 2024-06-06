using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Services
{
    public class ProductServiceProxy
    {
        private ProductServiceProxy() { 
           products = new List<Product>();
        }

        
        private static ProductServiceProxy? instance;
        private static object instanceLock = new object();

        
        public static ProductServiceProxy Current
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                    return instance;
                }

            }
        }

        private List<Product>? products;

        public ReadOnlyCollection<Product>? Products
        {
            get { return products?.AsReadOnly(); }
        }

    }
}
