using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories.Interfaces;
using static Server.Repositories.EfReportRepository;

namespace Server.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportsRepository _repository;
        public ReportController(IReportsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("get")]
        public async Task<IEnumerable<OrderReport>> GetReportOrders(string name, CancellationToken cancellationToken)
        {
            return await _repository.GetOrderReport(name, cancellationToken);
        }
        [HttpGet("replenish")]
        public async Task<IEnumerable<ReplenishReport>> GetReplenishReport(CancellationToken cancellationToken)
        {
            return await _repository.GetReplenishReport(cancellationToken);
        }
    }
}
