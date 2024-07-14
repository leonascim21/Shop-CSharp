using Shop.API.Database;
using Shop.Library.Models;
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
    }
}
