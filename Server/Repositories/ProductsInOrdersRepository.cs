using DataModel;

namespace Server.Repositories
{
    public class ProductsInOrdersRepository : EfRepository<ProductsInOrders>
    {
        public ProductsInOrdersRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
