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
        private readonly IRepository<ProductGroup> _repository;
        public ProductGroupController(IRepository<ProductGroup> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<ProductGroup>> GetProductGroups(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<ProductGroup> GetProductGroupById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await _repository.Add(productGroup, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await _repository.Update(productGroup, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProductGroup([FromBody] ProductGroup productGroup, CancellationToken cancellationToken)
        {
            await _repository.Remove(productGroup, cancellationToken);
        }
    }
}
