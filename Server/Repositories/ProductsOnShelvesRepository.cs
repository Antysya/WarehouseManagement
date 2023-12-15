using DataModel;
using Microsoft.EntityFrameworkCore;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class ProductsOnShelvesRepository : EfRepository<ProductsOnShelves>, IProductsOnShelvesRepository
    {
        public ProductsOnShelvesRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public override async Task<IEnumerable<ProductsOnShelves>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _entities
                .Include(p => p.Products)
                .Include(p => p.Shelving)
                .ToListAsync(cancellationToken);
        }
    }
}
