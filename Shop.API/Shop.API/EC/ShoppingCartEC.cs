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

        public async Task<Product> AddToCart(int CartId, Product product)
        {
            ShoppingCart? Cart = FakeDatabase.ShoppingCarts.FirstOrDefault(c => c.Id == CartId);
            if (Cart == null) return new Product();

            Product? inventoryProduct = FakeDatabase.Products.FirstOrDefault(p => p.Id == product.Id);
            if (inventoryProduct == null) return new Product();
            if (inventoryProduct.Quantity < product.Quantity) return new Product();

            Product? existingProduct = Cart.Contents?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
                inventoryProduct.Quantity -= product.Quantity;
                return new Product();
            }

            Cart.Contents?.Add(product);
            inventoryProduct.Quantity -= product.Quantity;
            return product;

        }
    }
}
