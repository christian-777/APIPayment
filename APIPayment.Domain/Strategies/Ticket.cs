using APIPayment.Domain.Contracts;

namespace APIPayment.Domain.Strategies
{
    public class Ticket : IStrategy
    {
        double IStrategy.Pay(double value)
        {
            return value;
        }
    }
}
