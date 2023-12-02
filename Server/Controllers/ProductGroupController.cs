using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/product-group")]
    //[ApiController]
    public class ProductGroupController : ControllerBase
    {
        private readonly IRepository<ProductGroup> repository;
        public ProductGroupController(IRepository<ProductGroup> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductGroup>> GetProductGroups(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductGroup> GetProductGroupById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await repository.Add(productGroup, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await repository.Update(productGroup, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await repository.Remove(productGroup, cancellationToken);
        }
    }
}
