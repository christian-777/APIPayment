using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository
{
    public class SQLRepository<TEntity> where TEntity : class , IRepository<TEntity>
    {
        private readonly ISQLContext _sqlContext;

        public SQLRepository(ISQLContext sqlContext)
        {
            _sqlContext = sqlContext;   
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _sqlContext.Set<TEntity>().Add(entity);
            return entity;
        }
    }
}