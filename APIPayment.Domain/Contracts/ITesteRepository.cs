using APIPayment.Domain.Entities;

namespace APIPayment.Infra.Repository.Repositories
{
    public interface ITesteRepository
    {
        Task Insert(Demand demand);
    }
}