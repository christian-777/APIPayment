using APIPayment.Domain.Contracts;

namespace APIPayment.Domain.Contexts
{
    public class StrategyContext
    { 
        public double ExecutePayment(IStrategy strategy, double value)
        {
            return strategy.Pay(value);
        }
    }
}
