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
        public ShoppingCart Cart;

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
            Cart = new ShoppingCart();
        }

        public void AddOrUpdateCart(Product product)
        {

            Product? inventoryProduct  = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if(inventoryProduct == null) { return; }
            
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

        public void RemoveFromCart(Product product)
        {
            Product? inventoryProduct = InventoryServiceProxy.Current.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if (inventoryProduct != null) { inventoryProduct.Quantity += product.Quantity; }

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null) { return;}

            Cart.Contents?.Remove(product);
        }

        public void Checkout()
        {
            Cart = new ShoppingCart();
        }


    }
}
