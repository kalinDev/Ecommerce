using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.DTOS.Customer
{
    public class CustomerDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
    }
}
