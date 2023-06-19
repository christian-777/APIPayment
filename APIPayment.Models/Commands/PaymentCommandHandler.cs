using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APiPayment.Services.Contexts;
using APIPayment.Models.Contracts;
using APIPayment.Models.Entities;
using APIPayment.Models.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Models.Commands
{
    public class PaymentCommandHandler
    {
        private readonly StrategyContext _context;
        private IRepository _repository;

        public PaymentCommandHandler(IRepository repository, StrategyContext strategyContext)
        {
            _context = strategyContext;
            _repository = repository;
        }

        public async Task<ActionResult<Payment>> Handler(Payment payment)
        {
            try
            {
                var strategy = payment.GetStrategy();
                var value = _context.ExecutePayment((IStrategy)strategy, payment.Value);
                payment.Value = value;
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
