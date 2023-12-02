using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/products-in-orders")]
    //[ApiController]
    public class ProductsInOrdersController : ControllerBase
    {
        private readonly IRepository<ProductsInOrders> repository;
        public ProductsInOrdersController(IRepository<ProductsInOrders> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductsInOrders>> GetProductsInOrders(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductsInOrders> GetProductInOrdersById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await repository.Add(productsInOrders, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await repository.Update(productsInOrders, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await repository.Remove(productsInOrders, cancellationToken);
        }
    }
}
