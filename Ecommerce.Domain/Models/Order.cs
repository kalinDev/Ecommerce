using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Models
{
    public class Order : Entity
    {
        public List<Product> Products { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }    

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
