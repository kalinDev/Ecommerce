using ECommerce.Domain.Models;

namespace ECommerce.Application.DTOS.Customer {
  public class DetailedCustomerDTO : CustomerDTO {
    public List<Address> Addresses { get; set; }
  }
}
