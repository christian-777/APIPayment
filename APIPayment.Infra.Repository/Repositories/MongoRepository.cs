using APIPayment.Domain.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository
{
    public class MongoRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly IMongoCollection<TEntity> _collection;
        public MongoRepository(IMongoClient client, IOptions<MongoRepositorySettings> options)
        {
            var db = client.GetDatabase(options.Value.DatabaseName);
            _collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<TEntity> InsertPayment(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> ListPayments()
        {
            return await _collection.Find(Entity => true).ToListAsync();
        }
    }
}