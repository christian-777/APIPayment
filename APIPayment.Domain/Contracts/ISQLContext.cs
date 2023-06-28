using Microsoft.EntityFrameworkCore;

namespace APIPayment.Domain.Contracts
{
    public interface ISQLContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<bool> SaveChanges();
    }
}
