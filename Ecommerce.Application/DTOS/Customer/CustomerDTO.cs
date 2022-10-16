using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOS.Customer
{
    public record class CustomerDTO
    {
        [Key]
        public Guid Id { get; init; }
        
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; init; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; init; }
        
        [Required]
        public DateTime BirthDate { get; init; }

    }
}
