using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository.Repositories
{
  
    public class SQLRepository<TEntity> : IRepository<TEntity>  where TEntity : class  
    {
        private readonly DbContext _sqlContext;

        public SQLRepository(DbContext sqlContext)
        {
            _sqlContext = sqlContext;   
        }

        public async Task Insert(TEntity entity)
        {
            await _sqlContext.Set<TEntity>().AddAsync(entity);
        }
    }
}