using DataModel;
using DataModel.Contract;
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


        public async Task<IEnumerable<ProductsInOrderResponse>> GetProductsByOrderId(int orderId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"OrderId: {orderId}");
            return await _entities
                .Include(po => po.Products) // Загрузить данные о продукте
                .Include(po => po.ProductStatusInOrder) // Загрузить статус продукта
                .Where(po => po.OrderId == orderId) // Применить условие на OrderId
                .Select(po => new ProductsInOrderResponse
              
                {
                    Id = po.Id,
                    Name = po.Products.Name,
                    Quantity = po.Quantity,
                    Status = po.ProductStatusInOrder.Name,
                    OrderId = po.OrderId
                })
                .ToListAsync(cancellationToken);
        }
    }
}
