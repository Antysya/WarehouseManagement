using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Repositories;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/orders")]
    //[ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Orders> repository;
        public OrdersController(IRepository<Orders> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Orders>> GetOrders(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<Orders> GetOrderById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await repository.Add(orders, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await repository.Update(orders, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await repository.Remove(orders, cancellationToken);
        }

    }
}
