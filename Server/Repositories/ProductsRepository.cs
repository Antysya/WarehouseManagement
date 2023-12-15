using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class ProductsRepository : EfRepository<Products>, IProductsRepository
    {
        public ProductsRepository(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Products>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _entities
                .Include(p => p.ProductGroup)
                .Include(p => p.ProductStatuses)
                .ToListAsync(cancellationToken);
        }

    }
}