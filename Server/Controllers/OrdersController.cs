using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Repositories;
using Server.Repositories.Interfaces;

namespace Server.Controllers
{
    [Route("api/orders")]
    [ApiController]    
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        public OrdersController(IOrdersRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get_all")]
        public async Task<IEnumerable<Orders>> GetOrders(CancellationToken cancellationToken)
        {
            return await _repository.GetAll(cancellationToken);
        }

        [HttpGet("get_order_in_progress")]
        public async Task<IEnumerable<Orders>> GetOrderInProgress(CancellationToken cancellationToken)
        {
            return await _repository.GetOrdersInProgress(cancellationToken);
        }

        [HttpPost("status/{id}")]
        public async Task<IActionResult> ChangeOrderStatus(int id, [FromHeader] string token, CancellationToken cancellationToken)
        {
            if (!await ValidateToken(token))
            {
                return Unauthorized("Недействительный токен");
            }

            var orderToUpdate = await _repository.GetById(id);
            if (orderToUpdate == null)
            {
                return NotFound();
            }
            int newStatusId = 4;
            orderToUpdate.OrderStatusId = newStatusId;
            await _repository.Update(orderToUpdate, cancellationToken);
            return Ok();
        }
        private async Task<bool> ValidateToken(string token)
        {
            // Реализация проверки токена
            return true;
        }

        [HttpGet("get")]
        public async Task<Orders> GetOrderById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        [HttpPost("add")]
        public async Task AddOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await _repository.Add(orders, cancellationToken);
        }

        [HttpPost("update")]
        public async Task UpdateOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await _repository.Update(orders, cancellationToken);
        }

        [HttpPost("remove")]
        public async Task RemoveOrder([FromBody] Orders orders, CancellationToken cancellationToken)
        {
            await _repository.Remove(orders, cancellationToken);
        }

    }
}
