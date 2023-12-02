using DataModel;
using System.Security.Principal;

namespace Server.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default);
        Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        Task Update(TEntity entity, CancellationToken cancellationToken = default);
        Task Remove(TEntity entity, CancellationToken cancellationToken = default);
    }
}