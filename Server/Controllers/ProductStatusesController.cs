using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/product-statuses")]
    //[ApiController]
    public class ProductStatusesController : ControllerBase
    {
        private readonly IRepository<ProductStatuses> _repository;
        public ProductStatusesController(IRepository<ProductStatuses> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductStatuses>> GetProductStatuses(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductStatuses> GetProductStatusById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await _repository.Add(productStatuses, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await _repository.Update(productStatuses, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await _repository.Remove(productStatuses, cancellationToken);
        }
    }
}
