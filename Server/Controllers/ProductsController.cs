using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/products")]
    //[ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Products> repository;
        public ProductsController(IRepository<Products> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Products>> GetProducts(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Products> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProduct([FromBody] Products products, CancellationToken cancellationToken)
        {
            await repository.Add(products, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProduct([FromBody] Products products, CancellationToken cancellationToken)
        {
            await repository.Update(products, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProduct([FromBody] Products Products, CancellationToken cancellationToken)
        {
            await repository.Remove(Products, cancellationToken);
        }
    }
}
