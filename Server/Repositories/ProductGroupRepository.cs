using DataModel;

namespace Server.Repositories
{
    public class ProductGroupRepository : EfRepository<ProductGroup>
    {
        public ProductGroupRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
