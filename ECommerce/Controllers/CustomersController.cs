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
        public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
        {
            return Ok( await _context.Customers.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetOneAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null) return NotFound();
            
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Customer customer)
        {
            var customerExists = await _context.Customers.AnyAsync(c => c.Email == customer.Email);
            if (customerExists) return Conflict("The email is already in use");
            
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id) return BadRequest();

            var customerExists = await _context.Customers.AnyAsync(c => c.Email == customer.Email && c.Id != id);
            if (customerExists) return Conflict("The email is already in use");

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null) return NotFound();

            _context.Customers.Remove(customer).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(e => e.Id == id);
        }
    }
}