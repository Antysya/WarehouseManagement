using DataModel;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class OrderStatusesRepository : EfRepository<OrderStatuses>
    {
        public OrderStatusesRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
