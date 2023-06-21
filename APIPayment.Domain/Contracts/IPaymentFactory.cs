namespace APIPayment.Domain.Contracts
{
    public interface IPaymentFactory
    {
        IStrategy GetStrategy(string paymentForm);
    }
}
