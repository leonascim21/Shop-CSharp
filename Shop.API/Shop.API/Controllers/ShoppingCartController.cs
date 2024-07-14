using Microsoft.AspNetCore.Mvc;
using Shop.API.EC;
using Shop.Library.Models;

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
    }
}
