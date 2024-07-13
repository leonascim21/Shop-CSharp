using Shop.API.Database;
using Shop_CSharp.Models;

namespace Shop.API.EC
{
    public class InventoryEC
    {
        private IEnumerable<Product> products {  get; set; } 
        public InventoryEC() 
        {
            
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return FakeDatabase.Products; 
        }
    }
}
