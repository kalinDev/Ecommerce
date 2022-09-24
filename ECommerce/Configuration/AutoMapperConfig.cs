using AutoMapper;
using ECommerce.Application.DTOS.Customer;
using ECommerce.Domain.Models;

namespace ECommerce.Configuration {
  public class AutoMapperConfig : Profile {
    public AutoMapperConfig() {
      CreateMap<Customer, CustomerDTO>().ReverseMap();
      CreateMap<Customer, DetailedCustomerDTO>().ReverseMap();
      CreateMap<Customer, PostCustomerDTO>().ReverseMap();
    }
  }
}
