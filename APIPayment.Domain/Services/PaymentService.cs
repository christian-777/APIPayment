using System.Web.Mvc;
using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Domain.Services
{
    public class PaymentService
    {
        private readonly StrategyContext _context;
        private IPaymentRepository _repository;
        private IPaymentFactory _factory;

        public PaymentService(IPaymentRepository repository, StrategyContext strategyContext, IPaymentFactory factory)
        {
            _context = strategyContext;
            _repository = repository;
            _factory = factory;
        }

        public async Task<ActionResult<Payment>> Handler(Payment payment)
        {
            try
            {
                var strategy = _factory.GetStrategy(payment.PaymentForm);
                var value = _context.ExecutePayment(strategy, payment.Value);
                payment.Value = value;
                payment.PaymentForm=payment.PaymentForm.ToUpper();
                await _repository.InsertPayment(payment);
                return payment;
            }
            catch 
            {
                return new BadRequestObjectResult("metodo de pagamento invalido");
            }
        }
    }
}
