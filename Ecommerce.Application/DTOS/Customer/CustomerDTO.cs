using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOS.Customer
{
    public record class CustomerDTO
    {
        [Key]
        public Guid Id { get; init; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; init; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; init; }
        
        [Required]
        public DateTime BirthDate { get; init; }

    }
}
