using DataModel;

namespace Server.Repositories
{
    public class ProductStatusInOrderRepository : EfRepository<ProductStatusInOrder>
    {
        public ProductStatusInOrderRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
