using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/product-status-in-order")]
    //[ApiController]
    public class ProductStatusInOrderController : ControllerBase
    {
        private readonly IRepository<ProductStatusInOrder> repository;
        public ProductStatusInOrderController(IRepository<ProductStatusInOrder> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductStatusInOrder>> GetProductStatusInOrder(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductStatusInOrder> GetProductStatusInOrderById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await repository.Add(productStatusInOrder, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await repository.Update(productStatusInOrder, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await repository.Remove(productStatusInOrder, cancellationToken);
        }
    }
}
