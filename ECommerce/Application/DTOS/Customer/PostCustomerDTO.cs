using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOS.Customer {
  public class PostCustomerDTO : CustomerDTO {
    [Required]
    [MaxLength(20)]
    public string Password { get; set; }
  }
}
