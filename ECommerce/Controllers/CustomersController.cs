using System.Runtime.InteropServices;
using ECommerce.Data;
using ECommerce.Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public CustomersController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return Ok( await _context.Customers.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null) return NotFound();
            
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}