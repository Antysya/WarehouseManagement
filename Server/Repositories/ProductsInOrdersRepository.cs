using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class ProductsInOrdersRepository : EfRepository<ProductsInOrders>, IProductsInOrdersRepository
    {
        public ProductsInOrdersRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public override async Task<IEnumerable<ProductsInOrders>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _entities
                .Include(p => p.Products)
                .Include(p => p.Orders)
                .Include(p => p.ProductStatusInOrder)
                .ToListAsync(cancellationToken);
        }

    }
}
