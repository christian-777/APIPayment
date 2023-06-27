using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository
{
    public class SQLRepository<TEntity> : IRepository<TEntity>
    {
        private readonly APIPaymentContext _contextEntity;
        private readonly ISQLContext _sqlContext;

        public SQLRepository(APIPaymentContext contextEntity, ISQLContext sqlContext)
        {
            _contextEntity = contextEntity;
            _sqlContext = sqlContext;   
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _sqlContext.AddCommand(()=>_contextEntity.AddAsync(entity).AsTask());
            return entity;
        }
    }
}