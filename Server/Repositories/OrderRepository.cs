﻿using DataModel;
using Microsoft.EntityFrameworkCore;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class OrderRepository: EfRepository<Orders>, IOrdersRepository
    {
        public OrderRepository(AppDbContext dbContext) 
            : base(dbContext) { }

        public override async Task<IEnumerable<Orders>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _entities
                .Include(p => p.OrderTypes)
                .Include(p => p.OrderStatuses)
                .ToListAsync(cancellationToken);
        }
    }
}
