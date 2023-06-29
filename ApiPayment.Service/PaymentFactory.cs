
using APIPayment.Domain.Contracts;

namespace APIPayment.Application
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IEnumerable<IStrategy> _strategys;

        public PaymentFactory(IEnumerable<IStrategy> strategys)
        {
            _strategys = strategys;
        }

        public IStrategy GetStrategy(string paymentForm)
        {
            try
            {
                var strategy = _strategys.Where(strategy => strategy.GetType().Name.Equals(paymentForm, StringComparison.InvariantCultureIgnoreCase)).First();
                return strategy;
            }
            catch(Exception) 
            {
                throw;            
            }
        }
    }
}
