using System.Linq.Expressions;

namespace ECommerce.Domain.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByIdAsync(Guid id);
        Task<List<TEntity>> FindAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(Guid id);
        Task<bool> AnyAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
