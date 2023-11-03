using Microsoft.AspNetCore.Mvc;
using MsCatalog.Entities;
using MsCatalog.Repositories;

namespace MsCatalog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MsCatalogController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public MsCatalogController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();

            return Ok(products);
        }
    }
}