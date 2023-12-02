using DataModel;

namespace Server.Repositories
{
    public class ShelvingRepository : EfRepository<Shelving>
    {
        public ShelvingRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
