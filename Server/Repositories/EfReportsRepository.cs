using DataModel;
using Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Server.Repositories
{
    public class EfReportRepository : IReportsRepository
    {
        protected readonly AppDbContext _dbContext;

        public EfReportRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<OrderReport>> GetOrderReport(string order, CancellationToken cancellationToken = default)
        {
            var result = await (from po in _dbContext.ProductsInOrders
                                join p in _dbContext.Products on po.ProductId equals p.Id
                                join ps in _dbContext.ProductsOnShelves on po.ProductId equals ps.ProductId
                                join s in _dbContext.Shelving on ps.ShelveId equals s.Id
                                join o in _dbContext.Orders on po.OrderId equals o.Id
                                where o.Name == order
                                select new OrderReport
                                {
                                    Product = p.Name,
                                    Code = p.Code,
                                    Quantity = po.Quantity,
                                    Placement = s.Line + "/" + s.Row + "/" + s.Number + "/" + s.Level
                                }).ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<ReplenishReport>> GetReplenishReport(CancellationToken cancellationToken = default)
        {
            var result = await (from p in _dbContext.Products
                        join ps in _dbContext.ProductsOnShelves on p.Id equals ps.ProductId into psJoin
                        from ps in psJoin.DefaultIfEmpty()
                        join s in _dbContext.ProductStatuses on p.ProductStatusId equals s.Id
                        join g in _dbContext.ProductGroup on p.ProductGroupId equals g.Id
                        where ps.Quantity <= p.MinimumStock
                        select new ReplenishReport
                        {
                            Product = p.Name,
                            Code = p.Code,
                            Group = g.Name,
                            Status = s.Name,
                            MinimumStock = p.MinimumStock,
                            Quantity = ps.Quantity
                        }).ToListAsync(cancellationToken);
            return result;
        }
    }
}
