using DataModel;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/order-type")]
    [ApiController]
    public class OrderTypesController
    {
        private readonly IRepository<OrderTypes> _repository;
        public OrderTypesController(IRepository<OrderTypes> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        [ProducesResponseType(typeof(IEnumerable<OrderTypes>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<OrderTypes>> GetOrderTypes(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(OrderTypes), StatusCodes.Status200OK)]
        public async Task<OrderTypes> GetOrderTypeById([FromBody]int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task AddOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await _repository.Add(orderTypes, cancellationToken);
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task UpdateOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await _repository.Update(orderTypes, cancellationToken);
        }

        [HttpPost("remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task RemoveOrderType([FromBody] OrderTypes orderTypes, CancellationToken cancellationToken)
        {
            await _repository.Remove(orderTypes, cancellationToken);
        }
    }
}
