using DataModel;

namespace Server.Repositories
{
    public class ProductStatusesRepository : EfRepository<ProductStatuses>
    {
        public ProductStatusesRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
