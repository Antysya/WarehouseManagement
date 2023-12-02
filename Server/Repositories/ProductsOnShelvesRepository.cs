using DataModel;

namespace Server.Repositories
{
    public class ProductsOnShelvesRepository : EfRepository<ProductsOnShelves>
    {
        public ProductsOnShelvesRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
