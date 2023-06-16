using APIPayment.Models.Contracts;
using APIPayment.Models.Entities;
using MongoDB.Driver;

namespace APIPayment.Repositories
{
    public class MongoRepository : IRepository
    {
        private readonly MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
        private IMongoCollection<Payment> Collection;
        public MongoRepository()
        {
            var db = mongoClient.GetDatabase("DBPayment");
            Collection = db.GetCollection<Payment>("Payments");
        }

        public async Task<Payment> InsertPayment(Payment payment)
        {
            await Collection.InsertOneAsync(payment);
            return payment;
        }

        public async Task<IEnumerable<Payment>> ListPayments()
        {
            return await Collection.Find(payment => true).ToListAsync();
        }
    }
}