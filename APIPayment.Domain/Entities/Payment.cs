using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIPayment.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public string CPF { get; set; }
        public string PaymentForm { get; set; }
        public double Value { get; set; }
    }
}