using Microsoft.AspNetCore.Mvc;
using Shop_CSharp.Models;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController
    {
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]

        public IEnumerable<Product> Get()
        {
            return new List<Product>
            {
                new Product{Id = 1, Name = "Apples", Price=1.75M, Quantity=25, Description="Red apples", Bogo=true},
                new Product{Id = 2, Name = "Bananas", Price=0.99M, Quantity=30, Description="Yellow bananas", Markdown=0.2},
                new Product{Id = 3, Name = "Oranges", Price=1.50M, Quantity=60, Description="Orange oranges"},
                new Product{Id = 4, Name = "Milk", Price=2.99M, Quantity=45, Description="1 gallon of milk"},
                new Product{Id = 5, Name = "Bread", Price=2.50M, Quantity=150, Description="bread loaf"},
                new Product{Id = 6, Name = "Eggs", Price=3.99M, Quantity=180, Description="One dozen eggs"},
                new Product{Id = 7, Name = "Cheese", Price=5.00M, Quantity=80, Description="Cheddar cheese", Bogo = true, Markdown = 0.1},
                new Product{Id = 8, Name = "Butter", Price=4.50M, Quantity=60, Description="Salted butter"},
                new Product{Id = 9, Name = "Chicken Breast", Price=7.99M, Quantity=90, Description="Chicken breast"},
                new Product{Id = 10, Name = "Ground Beef", Price=6.99M, Quantity=70, Description="1 lb of ground beef", Markdown = 0.5},
            };
        }
    }
}
