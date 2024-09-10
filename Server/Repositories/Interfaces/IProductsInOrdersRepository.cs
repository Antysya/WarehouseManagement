using DataModel;
using DataModel.Contract;
using System.Security.Principal;

namespace Server.Repositories.Interfaces
{
    public interface IProductsInOrdersRepository : IRepository<ProductsInOrders>
    {
        Task<IEnumerable<ProductsInOrderResponse>> GetProductsByOrderId(int orderId, CancellationToken cancellationToken = default);
    }
}