using ECommerce.Domain.Customers;
using ECommerce.Domain.Interfaces;

namespace ECommerce.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApiDbContext context) : base(context) { }
    }
}
