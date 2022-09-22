using AutoMapper;
using ECommerce.Application.DTOS.Customer;
using ECommerce.Domain.Customers;
using ECommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetOneAsync(int id)
        {
            var customer = await _repository.FindByIdAsync(id);

            if (customer is null) return NotFound();

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var customerExists = await _repository.SearchAsync(c => c.Email == customer.Email);
            if (customerExists != null) return Conflict("The email is already in use");
            
            await _repository.AddAsync(customer);
            
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            if (id != customer.Id) return BadRequest();

            var customerExists = await _repository.SearchAsync(c => c.Email == customer.Email && c.Id != id);
            if (customerExists != null) return Conflict("The email is already in use");

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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var customer = await _repository.FindByIdAsync(id);
            if (customer is null) return NotFound();

            await _repository.RemoveAsync(customer.Id);

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _repository.AnyAsync(id);
        }
    }
}