using DataModel;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/order-type")]
    [ApiController]
    public class OrderTypesController
    {
        private readonly IRepository<OrderTypes> repository;
        public OrderTypesController(IRepository<OrderTypes> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        [ProducesResponseType(typeof(IEnumerable<OrderTypes>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<OrderTypes>> GetOrderTypes(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(OrderTypes), StatusCodes.Status200OK)]
        public async Task<OrderTypes> GetOrderTypeById([FromBody]int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task AddOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Add(orderTypes, cancellationToken);
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task UpdateOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Update(orderTypes, cancellationToken);
        }

        [HttpPost("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task RemoveOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await repository.Remove(orderTypes, cancellationToken);
        }
    }
}
