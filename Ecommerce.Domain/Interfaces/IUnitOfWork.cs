namespace ECommerce.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task RollbackAsync();
    }
}
