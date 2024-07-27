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
            return new DbContext().GetProducts(); 
        }

        public async Task<Product> Post(Product p)
        {
            bool isAdd = false;
            if (p.Id == 0)
            {
               isAdd = true;
                p.Id = FakeDatabase.NextProductId;
            }

            if (isAdd)
            {
                new DbContext().AddProduct(p);
            }
            else
            {
                new DbContext().UpdateProduct(p);
            }
            return p;
        }

        public async Task<Product> Delete (int Id)
        {
            Product? ProductToDelete = FakeDatabase.Products.FirstOrDefault(prod => prod.Id == Id);
            if(ProductToDelete != null)
            {
                new DbContext().DeleteProduct(Id); ;
            }
            return ProductToDelete ?? new Product();
        }
    }
}
