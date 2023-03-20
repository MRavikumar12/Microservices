using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment_MDB_API.Models;
using Payment_MDB_API.Services;

namespace Payment_MDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<List<Payment>> Get() =>
            await _paymentService.GetPayments();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Payment>> GetById(string id)
        {
            var pay = await _paymentService.GetPaymentById(id);
            if (pay is null)
            {
                return NotFound();
            }
            return Ok(pay);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Payment payment)
        {
            await _paymentService.CreatePayment(payment);
            return Ok(payment);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> Update(string id, Payment payment)
        {
            var pay = await _paymentService.GetPaymentById(id);
            if (pay is null)
            {
                return NotFound();
            }
            payment.id = pay.id;
            await _paymentService.UpdatePayment(id, payment);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            var pay=_paymentService.GetPaymentById(id);
            if(pay is null)
            {
                return NotFound();
            }
            await _paymentService.DeletePayment(id);
            return NoContent();
        }
    }
}
