using ECommerce.Domain.Models;

namespace ECommerce.Application.DTOS.Customer
{
    public class DetailedCustomerDTO : CustomerDTO
    {
        public Guid Id { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
