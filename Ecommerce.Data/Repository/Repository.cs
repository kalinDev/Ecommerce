using System.Linq.Expressions;
using ECommerce.Domain;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() 
    {
        protected readonly ApiDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApiDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<TEntity> FindByIdAsync(Guid id) => 
            await DbSet.FindAsync(id);

        public async Task<List<TEntity>> FindAsync() =>
            await DbSet.ToListAsync();

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public async Task<bool> AnyAsync(Guid id) =>
            await DbSet.AnyAsync(e => e.Id == id);

        public async Task<int> SaveChangesAsync() =>
            await Db.SaveChangesAsync();

        public void Dispose() => 
            Db?.Dispose();
    }
}
