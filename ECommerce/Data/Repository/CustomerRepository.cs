using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repository
{
public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApiDbContext context) : base(context)
    {

    }

    public async Task<Customer> FindByIdWithAddress(Guid id)
    {
        return await Db.Customers.AsNoTracking()
               .Include(c => c.Addresses)
               .FirstOrDefaultAsync(c => c.Id == id);
    }
}
}
