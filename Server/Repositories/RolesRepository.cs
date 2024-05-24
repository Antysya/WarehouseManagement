using DataModel;

namespace Server.Repositories
{
    public class RolesRepository : EfRepository<Roles>
    {
        public RolesRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}
