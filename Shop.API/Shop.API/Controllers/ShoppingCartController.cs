using Microsoft.AspNetCore.Mvc;
using Shop.API.EC;
using Shop.Library.Models;
using Shop_CSharp.Models;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController
    {
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IEnumerable<ShoppingCart>> Get()
        {
            return await new ShoppingCartEC().Get();
        }

        [HttpPost()]
        public async void Post([FromBody] string name)
        {
            new ShoppingCartEC().Post(name);
        }

        [HttpPost("/ShoppingCart/{CartId}")]
        public async void AddToCart(int CartId, [FromBody] Product product)
        {
            new ShoppingCartEC().AddToCart(CartId, product);
        }

        [HttpDelete("/ShoppingCart/{CartId}/{ProductId}")]
        public async void RemoveFromCart(int CartId, int ProductId)
        {
            new ShoppingCartEC().RemoveFromCart(CartId, ProductId);
        }

        [HttpDelete("/ShoppingCart/Checkout/{CartId}")]
        public async void Checkout(int CartId)
        {
            new ShoppingCartEC().Checkout(CartId);
        }
    }
}
