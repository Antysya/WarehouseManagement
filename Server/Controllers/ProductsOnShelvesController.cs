using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/products-on-shelves")]
    //[ApiController]
    public class ProductsOnShelvesController : ControllerBase
    {
        private readonly IProductsOnShelvesRepository _repository;
        public ProductsOnShelvesController(IProductsOnShelvesRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductsOnShelves>> GetProductsOnShelves(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductsOnShelves> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await _repository.Add(productsOnShelves, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await _repository.Update(productsOnShelves, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await _repository.Remove(productsOnShelves, cancellationToken);
        }
    }
}
