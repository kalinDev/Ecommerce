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

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Guid id) =>
    await DbSet.AnyAsync(e => e.Id == id);

    public async Task<int> SaveChangesAsync() =>
    await Db.SaveChangesAsync();

    public void Dispose() =>
    Db?.Dispose();
}
}
