using Microsoft.AspNetCore.Mvc;
using Shop.API.Database;
using Shop.Library.Models;
using Shop.Library.Services;
using Shop_CSharp.Models;

namespace Shop.API.EC
{
    public class ShoppingCartEC
    {
        public ShoppingCartEC() 
        {
        
        }
        public async Task<IEnumerable<ShoppingCart>> Get()
        {
            return FakeDatabase.ShoppingCarts;
        }

        public async void Post(string name)
        {
            FakeDatabase.ShoppingCarts.Add(new ShoppingCart(name, FakeDatabase.NextCartId));
        }

        public async void AddToCart(int CartId, Product product)
        {
            ShoppingCart? Cart = FakeDatabase.ShoppingCarts.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Product? inventoryProduct = new DbContext().GetProduct(product.Id);
            if (inventoryProduct == null) return;
            if (inventoryProduct.Quantity < product.Quantity) return;

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
                inventoryProduct.Quantity -= product.Quantity;
                new DbContext().UpdateProduct(inventoryProduct);
                return;
            }

            Cart.Contents?.Add(product);
            inventoryProduct.Quantity -= product.Quantity;
            new DbContext().UpdateProduct(inventoryProduct);
        }

        public async void RemoveFromCart(int CartId, int ProductId)
        {
            ShoppingCart? Cart = FakeDatabase.ShoppingCarts.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == ProductId);
            if (existingProduct == null) { return; }

            Product? inventoryProduct = new DbContext().GetProduct(ProductId);
            if (inventoryProduct != null) 
            { 
                inventoryProduct.Quantity += existingProduct.Quantity;
                new DbContext().UpdateProduct(inventoryProduct);
            }
            Cart.Contents?.Remove(existingProduct);
        }
        public async void Checkout(int CartId)
        {
            ShoppingCart? Cart = FakeDatabase.ShoppingCarts.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return;

            Cart?.Contents?.Clear();
        }
    }
}
