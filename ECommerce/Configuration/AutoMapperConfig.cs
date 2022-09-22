using AutoMapper;
using ECommerce.Application.DTOS.Customer;
using ECommerce.Domain.Customers;

namespace ECommerce.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
