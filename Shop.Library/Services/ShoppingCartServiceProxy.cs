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

        public ReadOnlyCollection<ShoppingCart> carts;

        public ShoppingCart Cart
        {
            get
            {
                if (carts == null || !carts.Any())
                {
                    return new ShoppingCart();
                }
                return carts?.FirstOrDefault() ?? new ShoppingCart();
            }
        }

        private ShoppingCartServiceProxy() { }

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

        public void AddToCart(Product newProduct)
        {
            if (Cart == null || Cart.Contents == null)
            {
                return;
            }

            var existingProduct = Cart?.Contents?
                .FirstOrDefault(existingProducts => existingProducts.Id == newProduct.Id);

            var inventoryProduct = InventoryServiceProxy.Current.Products.FirstOrDefault(invProd => invProd.Id == newProduct.Id);
            if (inventoryProduct == null)
            {
                return;
            }

            inventoryProduct.Quantity -= newProduct.SelectedQuantity;

            if (existingProduct != null)
            {

                existingProduct.Quantity += newProduct.SelectedQuantity;
            }
            else
            {
                Cart.Contents.Add(newProduct);
            }
        }

    }
}
