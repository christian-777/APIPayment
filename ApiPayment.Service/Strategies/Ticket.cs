using APIPayment.Domain.Contracts;

namespace APIPayment.Application.Strategies
{
    public class Ticket : IStrategy
    {
        double IStrategy.Pay(double value)
        {
            return value;
        }
    }
}
