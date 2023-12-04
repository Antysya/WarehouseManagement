using DataModel;
using Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected DbSet<TEntity> _entities => _dbContext.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
           return await _entities.ToListAsync(cancellationToken);
        }
        public virtual async Task<TEntity> GetById(int id, CancellationToken cancellationToken = default) =>
             await _entities.FirstAsync(it => it.Id == id, cancellationToken);

        public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            
        }

        public virtual Task Remove(TEntity entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
