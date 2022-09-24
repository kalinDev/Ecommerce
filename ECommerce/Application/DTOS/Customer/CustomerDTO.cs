using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOS.Customer {
  public class CustomerDTO {
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name {
      get; set;
    }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email {
      get; set;
    }

    [Required]
    public DateTime BirthDate {
      get; set;
    }
  }
}
