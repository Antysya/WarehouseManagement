using DataModel;

namespace Server.Repositories
{
    public class ProductsRepository : EfRepository<Products>
    {
        public ProductsRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
