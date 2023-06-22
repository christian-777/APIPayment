using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository.Repositories
{
    public class PaymentRepository : MongoRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(IMongoClient client, IOptions<MongoRepositorySettings> options): base(client, options)
        {
            
        }
    }
}
