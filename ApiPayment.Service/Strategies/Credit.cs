using APIPayment.Domain.Contracts;

namespace APIPayment.Application.Strategies
{
    public class Credit : IStrategy 
    {
        double IStrategy.Pay(double value)
        {
            return value * 1.1;
        }
    }
}
