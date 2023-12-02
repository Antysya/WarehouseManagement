using DataModel;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class OrderRepository: EfRepository<Orders>
    {
        public OrderRepository(AppDbContext dbContext) 
            : base(dbContext) { }
    }
}
