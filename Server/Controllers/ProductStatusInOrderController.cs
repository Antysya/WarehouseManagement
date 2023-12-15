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
        private readonly IRepository<ProductStatusInOrder> _repository;
        public ProductStatusInOrderController(IRepository<ProductStatusInOrder> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductStatusInOrder>> GetProductStatusInOrder(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductStatusInOrder> GetProductStatusInOrderById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await _repository.Add(productStatusInOrder, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await _repository.Update(productStatusInOrder, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductStatusInOrder([FromBody] ProductStatusInOrder productStatusInOrder, CancellationToken cancellationToken)
        {
            await _repository.Remove(productStatusInOrder, cancellationToken);
        }
    }
}
