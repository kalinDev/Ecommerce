using ECommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace ECommerce.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByIdAsync(Guid id);
        Task<List<TEntity>> FindAsync();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);
        Task<bool> AnyAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
