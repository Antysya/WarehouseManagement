using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Server.Repositories.Interfaces;
using System.Runtime.CompilerServices;

namespace Server.Controllers
{
    [Route("api/products")]
    //[ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;

        public ProductsController(IProductsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Products>> GetProducts(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Products> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddProduct([FromBody] Products products, CancellationToken cancellationToken)
        {
            await _repository.Add(products, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateProduct([FromBody] Products products, CancellationToken cancellationToken)
        {
            await _repository.Update(products, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveProduct([FromBody] Products Products, CancellationToken cancellationToken)
        {
            await _repository.Remove(Products, cancellationToken);
        }
    }
}
