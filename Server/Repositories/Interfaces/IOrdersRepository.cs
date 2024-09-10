using DataModel;
using System.Security.Principal;

namespace Server.Repositories.Interfaces
{
    public interface IOrdersRepository: IRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetOrdersInProgress(CancellationToken cancellationToken = default);
    }
}