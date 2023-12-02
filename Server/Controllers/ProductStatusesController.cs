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
        private readonly IRepository<ProductStatuses> repository;
        public ProductStatusesController(IRepository<ProductStatuses> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductStatuses>> GetProductStatuses(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductStatuses> GetProductStatusById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await repository.Add(productStatuses, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await repository.Update(productStatuses, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductStatus([FromBody] ProductStatuses productStatuses, CancellationToken cancellationToken)
        {
            await repository.Remove(productStatuses, cancellationToken);
        }
    }
}
