using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.API.Commadns;
using Products.API.Models;
using Products.API.Queries;

namespace Products.API.Controllers
{
    [EnableCors("products")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TProduct>>> GetCustomers()
        {
            var prod=await _mediator.Send(new GetPrroductQuery());
            return Ok(prod);
        }  
        
        // GET: api/customers/5

       /* [HttpGet("{id}")]
        public async Task<ActionResult<TProduct>> GetCustomer(int id)
        {
            var customer = await _mediator.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }*/

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<TProduct>> PostCustomer(TProduct product)
        {
           await _mediator.Send(new AddProductCommand(product));
            return Ok(product);
        }
        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, TProduct customer)
        {
            if (id != customer.ProdId)
            {
                return BadRequest();
            }
            else
            {

            await _mediator.Send(new UpdateProductCommand(customer));
            return Ok(customer);       
            }
           
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
           await _mediator.Send(new DeleteProductCommand(id));
            return StatusCode(200);
        }
       
    }
}

