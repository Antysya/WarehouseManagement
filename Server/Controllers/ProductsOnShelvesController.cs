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
        private readonly IRepository<ProductsOnShelves> repository;
        public ProductsOnShelvesController(IRepository<ProductsOnShelves> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductsOnShelves>> GetProductsOnShelves(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductsOnShelves> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await repository.Add(productsOnShelves, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await repository.Update(productsOnShelves, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductOnShelves([FromBody] ProductsOnShelves productsOnShelves, CancellationToken cancellationToken)
        {
            await repository.Remove(productsOnShelves, cancellationToken);
        }
    }
}
