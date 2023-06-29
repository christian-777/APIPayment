using APIPayment.Domain.Contracts;

namespace APIPayment.Application.Strategies
{
    public class Pix : IStrategy
    {
        double IStrategy.Pay(double value)
        {
            return value * 0.89;
        }
    }
}
