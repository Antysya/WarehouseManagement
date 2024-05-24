using DataModel;
using Microsoft.EntityFrameworkCore;
using Server.Repositories.Interfaces;

namespace Server.Repositories
{
    public class UsersRepository : EfRepository<Users>, IUsersRepository
    {
        public UsersRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task<Users> GetByLogin(string login, CancellationToken cancellationToken = default) =>
            await _entities.FirstAsync(it => it.Login == login, cancellationToken);

        public override async Task Add (Users user, CancellationToken cancellationToken)
        {
            var userNew = new Users
            {
                Id = user.Id,
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId
            };

            await _dbContext.Users.AddAsync(userNew, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public override async Task<IEnumerable<Users>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _entities
                .ToListAsync(cancellationToken);
        }
    }
}
