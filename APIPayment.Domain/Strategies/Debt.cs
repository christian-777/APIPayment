using APIPayment.Domain.Contracts;

namespace APIPayment.Domain.Strategies
{
    public class Debt : IStrategy
    {
        double IStrategy.Pay(double value)
        {
            return value * 0.9; 
        }
    }
}
