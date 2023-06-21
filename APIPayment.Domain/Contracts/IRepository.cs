namespace APIPayment.Domain.Contracts
{
    public interface IRepository<TEnitity> 
    {
        Task<TEnitity> InsertPayment(TEnitity enitity);
        Task<IEnumerable<TEnitity>> ListPayments();
    }
}
