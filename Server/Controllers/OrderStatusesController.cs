using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/order-statuses")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        private readonly IRepository<OrderStatuses> _repository;
        public OrderStatusesController(IRepository<OrderStatuses> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<OrderStatuses>> GetOrderStatuses(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<OrderStatuses> GetOrderStatusById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await _repository.Add(orderStatuses, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await _repository.Update(orderStatuses, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await _repository.Remove(orderStatuses, cancellationToken);
        }
    }
}
