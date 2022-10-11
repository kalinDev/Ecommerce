using ECommerce.Application.Interfaces;
using ECommerce.Application.Validations;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;

namespace ECommerce.Application.Services
{
    public class CustomerService : BaseService, ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, INotifier notifier) : base(notifier)
            => _customerRepository = customerRepository;

        public async Task AddAsync(Customer customer)
        {
            if (!RunValidation(new CustomerValidation(), customer)) return;

            var customerExists = (await _customerRepository.SearchAsync(c => c.Email == customer.Email))?.Any();
            if (customerExists is true)
            {
                Notify("The email is already in use");
                return;
            }
            
            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync(); 

        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerExists = (await _customerRepository.SearchAsync(c => c.Email == customer.Email && c.Id != customer.Id))?.Any();
            if (customerExists is true)
            {
                Notify("The email is already in use");
                return;
            }

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();
        }
        
    }
}
