using ECommerce.Domain.Models;

namespace ECommerce.Application.Interfaces
{
    public interface ICustomerService
    {
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
