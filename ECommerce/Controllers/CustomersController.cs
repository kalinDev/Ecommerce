using AutoMapper;
using ECommerce.Application.Interfaces;
using ECommerce.Application.DTOS.Customer;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Services.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repository, ICustomerService service, IMapper mapper, INotifier notifier) : base (notifier)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
            => Ok(_mapper.Map<IEnumerable<CustomerDTO>>(await _repository.FindAsync()));

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Customer>> GetOneAsync(Guid id)
        {
            var customer = await _repository.FindByIdWithAddress(id);

            if (customer is null) return NotFound();

            return CustomResponse(_mapper.Map<DetailedCustomerDTO>(customer));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PostCustomerDTO postCustomerDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.AddAsync(_mapper.Map<Customer>(postCustomerDTO));

            return CustomResponse();
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> PutAsync(Guid id, [FromBody] CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (id != customerDTO.Id) return BadRequest();

            var customer = await _repository.FindByIdWithAddress(id);
            if (customer is null) return NotFound();

            var customerUpdated = _mapper.Map(customerDTO, customer);
            await _service.UpdateAsync(customerUpdated);
            
            return CustomResponse();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var customer = await _repository.FindByIdAsync(id);
            if (customer is null) return NotFound();

            _repository.Remove(customer.Id);
            await _repository.SaveChangesAsync();

            return Ok(_mapper.Map<CustomerDTO>(customer));
        }
    }
}