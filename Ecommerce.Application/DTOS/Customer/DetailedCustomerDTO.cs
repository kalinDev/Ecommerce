using ECommerce.Domain.Models;

namespace ECommerce.Application.DTOS.Customer
{
    public record class DetailedCustomerDTO : CustomerDTO
    {
        public List<Address> Addresses { get; init; }
    }
}
