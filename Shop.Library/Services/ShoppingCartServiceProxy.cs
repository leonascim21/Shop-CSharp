using Shop.Library.Models;
using Shop_CSharp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Library.Services
{
    public class ShoppingCartServiceProxy
    {
        private static ShoppingCartServiceProxy? instance;
        private static object instanceLock = new object();
        public List<ShoppingCart> CartList;
        
        public int NextId { 
            get 
            {
                if (!CartList.Any())
                {
                    return 1;
                }

                return CartList.Select(p => p.Id).Max() + 1;
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
            CartList = new List<ShoppingCart>();
            AddCart("Shopping Cart");
        }

        public void AddCart(string name)
        {
            CartList.Add(new ShoppingCart(name, NextId));
        }

        public void AddOrUpdateCart(Product product, int CartId)
        {

            ShoppingCart? Cart = CartList.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Product? inventoryProduct  = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if(inventoryProduct == null) return; 
            if(inventoryProduct.Quantity < product.Quantity)  return;

            Product? existingProduct = Cart.Contents?
                .FirstOrDefault(p => p.Id == product.Id);
            if(existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
                inventoryProduct.Quantity -= product.Quantity;
                return;
            }

            Cart.Contents?.Add(product);
            inventoryProduct.Quantity -= product.Quantity;
        }

        public void RemoveFromCart(Product product, int CartId)
        {
            ShoppingCart? Cart = CartList.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Product? inventoryProduct = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if (inventoryProduct != null) { inventoryProduct.Quantity += product.Quantity; }

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null) { return;}

            Cart.Contents?.Remove(product);
        }

        public void Checkout(int CartId)
        {
            ShoppingCart? Cart = CartList.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Cart?.Contents?.Clear();
        }


    }
}
