using DataModel;
using Microsoft.AspNetCore.Mvc;
using static Server.Repositories.EfReportRepository;

namespace Server.Repositories.Interfaces
{
    public interface IReportsRepository
    {
        Task<IEnumerable<OrderReport>> GetOrderReport(string order, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReplenishReport>> GetReplenishReport(CancellationToken cancellationToken = default);
    }
}
