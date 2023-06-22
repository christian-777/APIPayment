using APIPayment.Domain.Services;
using APIPayment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Controllers
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

        [HttpPost(Name = "Insert Payment")]
        public Task<ActionResult<Payment>> InsertPayment([FromBody] Payment payment)
        {
            payment.Id = "";
            return _paymentService.Handler(payment);
        }
    }
}
