namespace APIPayment.Domain.Contracts
{
    public interface IRepository<TEnitity> 
    {
        Task<TEnitity> Insert(TEnitity enitity);
    }
}
