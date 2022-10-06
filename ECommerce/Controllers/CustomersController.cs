using AutoMapper;
using ECommerce.Application.DTOS.Customer;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerDTO>>(await _repository.FindAsync()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Customer>> GetOneAsync(Guid id)
        {
            var customer = await _repository.FindByIdWithAddress(id);

            if (customer is null) return NotFound();

            return Ok(_mapper.Map<DetailedCustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PostCustomerDTO postCustomerDTO)
        {
            var customer = _mapper.Map<Customer>(postCustomerDTO);
            var customerExists = (await _repository.SearchAsync(c => c.Email == customer.Email)).Any();
            if (customerExists) return Conflict("The email is already in use");
            
            await _repository.AddAsync(customer);
            
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            if (id != customer.Id) return BadRequest();

            var customerExists = (await _repository.SearchAsync(c => c.Email == customer.Email && c.Id != id)).Any();
            if (customerExists) return Conflict("The email is already in use");

            try
            {
                await _repository.UpdateAsync(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var customer = await _repository.FindByIdAsync(id);
            if (customer is null) return NotFound();

            await _repository.RemoveAsync(customer.Id);

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        private async Task<bool> CustomerExists(Guid id) => 
            await _repository.AnyAsync(id);
    }
}