using System.Runtime.CompilerServices;
using APiPayment.Services.Contexts;
using APIPayment.Models.Strategies;
using APIPayment.Models.Commands;
using APIPayment.Models.Contracts;
using APIPayment.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentCommandHandler _paymentCommandHandler;
        //private IRepository repository;

        public PaymentsController(PaymentCommandHandler paymentCommandHandler)
        {
            _paymentCommandHandler = paymentCommandHandler;
        }

        [HttpPost(Name = "Insert Payment")]
        public Task<ActionResult<Payment>> InsertPayment([FromBody] Payment payment)
        {
            payment.Id = "";
            return _paymentCommandHandler.Handler(payment);
        }
    }
}
