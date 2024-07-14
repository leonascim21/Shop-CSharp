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

        public async Task<Product> Post(Product p)
        {
            bool isAdd = false;
            if (p.Id == 0)
            {
               isAdd = true;
                p.Id = FakeDatabase.NextId;
            }

            if (isAdd)
            {
                FakeDatabase.Products.Add(p);
            }
            else
            {
                Product ProductToEdit = FakeDatabase.Products.First(prod => prod.Id == p.Id);
                if (ProductToEdit != null)
                {
                    ProductToEdit.Name = p.Name;
                    ProductToEdit.Description = p.Description;
                    ProductToEdit.Price = p.Price;
                    ProductToEdit.Quantity = p.Quantity;
                    ProductToEdit.Markdown = p.Markdown;
                    ProductToEdit.Bogo = p.Bogo;
                }
            }
            
            return p;
        }
    }
}
