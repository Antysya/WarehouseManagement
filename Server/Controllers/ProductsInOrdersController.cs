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
        private readonly IProductsInOrdersRepository _repository;
        public ProductsInOrdersController(IProductsInOrdersRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductsInOrders>> GetProductsInOrders(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductsInOrders> GetProductInOrdersById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await _repository.Add(productsInOrders, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await _repository.Update(productsInOrders, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductInOrders([FromBody] ProductsInOrders productsInOrders, CancellationToken cancellationToken)
        {
            await _repository.Remove(productsInOrders, cancellationToken);
        }
    }
}
