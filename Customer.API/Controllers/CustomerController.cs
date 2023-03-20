using Customer.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Controllers
{
    [EnableCors("customers")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MicroDbContext _context; 
        public CustomerController(MicroDbContext context)
        {
            _context = context;
        }        
        
        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TCustomer>>> GetCustomers()
        {
            return await _context.TCustomers.ToListAsync();
        }       
        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TCustomer>> GetCustomer(int id)
        {
            var customer = await _context.TCustomers.FindAsync(id); 
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }        
        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<TCustomer>> PostCustomer(TCustomer customer)
        {
            _context.TCustomers.Add(customer);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustId }, customer);
        }       
        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, TCustomer customer)
        {
            if (id != customer.CustId)
            {
                return BadRequest();
            }
            _context.Entry(customer).State = EntityState.Modified; 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }       
        
        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.TCustomers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.TCustomers.Remove(customer);
            await _context.SaveChangesAsync(); return NoContent();
        }
        private bool CustomerExists(int id)
        {
            return _context.TCustomers.Any(e => e.CustId == id);
        }
    }

}

