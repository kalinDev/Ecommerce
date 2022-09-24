namespace ECommerce.Domain.Models {
  public class Address : Entity {
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
  }
}
