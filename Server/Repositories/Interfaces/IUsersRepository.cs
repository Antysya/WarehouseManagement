using DataModel;
using System.Security.Principal;

namespace Server.Repositories.Interfaces
{
    public interface IUsersRepository: IRepository<Users>
    {
        Task<Users> GetByLogin(string login, CancellationToken cancellationToken = default);
        Task<IEnumerable<Users>> GetAll(CancellationToken cancellationToken = default);
    }
}