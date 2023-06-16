using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APiPayment.Services.Contexts;
using APIPayment.Models.Contracts;
using APIPayment.Models.Dictionaries;
using APIPayment.Models.Entities;

namespace APIPayment.Models.Commands
{
    public class PaymentCommandHandler
    {
        private readonly StrategyContext _context;
        private readonly PaymentDictionary _paymentDictionary;
        private IRepository _repository;

        public PaymentCommandHandler(IRepository repository)
        {
            _context = new StrategyContext();
            _paymentDictionary = new PaymentDictionary();
            _repository = repository;
        }

        public async Task<Payment> Handler(Payment payment)
        {
            var calculatadePrice = _context.ExecutePayment(_paymentDictionary.GetPaymentType(payment.PaymentForm), payment.Value);

            payment.Value = calculatadePrice;
            
            return _repository.InsertPayment(payment).Result;
        }
    }
}
