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
        private readonly IRepository<OrderStatuses> repository;
        public OrderStatusesController(IRepository<OrderStatuses> dbContext)
        {
            repository = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<OrderStatuses>> GetOrderStatuses(CancellationToken cancellationToken)
        {
            return await repository.GetAll(cancellationToken);
        }

        [HttpGet("get")]
        public async Task<OrderStatuses> GetOrderStatusById(int id, CancellationToken cancellationToken)
        {
            return await repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await repository.Add(orderStatuses, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await repository.Update(orderStatuses, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveOrderStatus([FromBody] OrderStatuses orderStatuses, CancellationToken cancellationToken)
        {
            await repository.Remove(orderStatuses, cancellationToken);
        }
    }
}
