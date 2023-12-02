using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Repositories;
using Server;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/order-types")]
    //[ApiController]
    public class OrderTypesController
    {
        private readonly IRepository<OrderTypes> repository;
        public OrderTypesController(IRepository<OrderTypes> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<OrderTypes>> GetOrderTypes(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<OrderTypes> GetOrderTypeById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Add(orderTypes, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Update(orderTypes, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Remove(orderTypes, cancellationToken);
        }
    }
}
