using DataModel;

namespace Server.Repositories
{
    public class OrderTypesRepository : EfRepository<OrderTypes>
    {
        public OrderTypesRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
