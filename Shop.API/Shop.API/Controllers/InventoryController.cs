using Microsoft.AspNetCore.Mvc;
using Shop.API.EC;
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
        public async Task<IEnumerable<Product>> Get()
        {
            return await new InventoryEC().Get();
        }

        [HttpPost()]
        public async Task<Product> Post([FromBody] Product p)
        {
            return await new InventoryEC().Post(p);
        }
    }
}
