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

        public void RemoveFromCart(Product product, int CartId)
        {
            ShoppingCart? Cart = cartList.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Product? inventoryProduct = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if (inventoryProduct != null) { inventoryProduct.Quantity += product.Quantity; }

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null) { return; }

            Cart.Contents?.Remove(product);
        }

        public void Checkout(int CartId)
        {
            ShoppingCart? Cart = cartList.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Cart?.Contents?.Clear();
        }


    }
}
