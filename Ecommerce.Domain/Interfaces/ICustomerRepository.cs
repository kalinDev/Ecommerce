using ECommerce.Domain.Models;

namespace ECommerce.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> FindByIdWithAddress(Guid id);
    }
}
