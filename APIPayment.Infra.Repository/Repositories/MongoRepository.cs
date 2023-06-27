using APIPayment.Domain.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository
{
    public class MongoRepository<TEntity> : IRepository<TEntity>
    {
        protected readonly IMongoCollection<TEntity> _collection;
        private readonly IMongoContext _context;
        public MongoRepository(IMongoClient client, IOptions<MongoRepositorySettings> options, IMongoContext context)
        {
            var db = client.GetDatabase(options.Value.DatabaseName);
            _collection = db.GetCollection<TEntity>(typeof(TEntity).Name);
            _context = context;
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _context.AddCommand(()=> _collection.InsertOneAsync(entity));
            return entity;
        }

        public async Task<IEnumerable<TEntity>> List()
        {
            return await _collection.Find(Entity => true).ToListAsync();
        }
    }
}