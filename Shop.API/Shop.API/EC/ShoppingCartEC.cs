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
    }
}
