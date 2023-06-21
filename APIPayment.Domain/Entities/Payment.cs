using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIPayment.Domain.Entities
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string CPF { get; set; }
        public string PaymentForm { get; set; }
        public double Value { get; set; }
    }
}