using Newtonsoft.Json;
using Shop.Library.Models;
using Shop.Library.Utilities;
using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Shop.Library.Services
{
    public class ShoppingCartServiceProxy
    {
        private static ShoppingCartServiceProxy? instance;
        private static object instanceLock = new object();

        private List<ShoppingCart> cartList;
        public ReadOnlyCollection<ShoppingCart> CartList 
        { 
            get
            {
                return cartList.AsReadOnly();
            }
        }

        

        public static ShoppingCartServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ShoppingCartServiceProxy();
                    }
                }
                return instance;
            }
        }

        private ShoppingCartServiceProxy() 
        {
            Get();
        }

        public void Get()
        {
            var response = new WebRequestHandler().Get("/ShoppingCart").Result;
            cartList = JsonConvert.DeserializeObject<List<ShoppingCart>>(response);
        }

        public void AddCart(string name)
        {
            new WebRequestHandler().Post("/ShoppingCart", name);
        }

        public async Task<Product> AddOrUpdateCart(Product product, int CartId)
        {
            await new WebRequestHandler().Post($"/ShoppingCart/{CartId}", product);
            return product;
        }

        public async Task<Product> RemoveFromCart(Product product, int CartId)
        {
            new WebRequestHandler().Delete($"/ShoppingCart/{CartId}/{product.Id}");
            return product;
        }

        public void Checkout(int CartId)
        {
            new WebRequestHandler().Delete($"/ShoppingCart/Checkout/{CartId}");
        }


    }
}
