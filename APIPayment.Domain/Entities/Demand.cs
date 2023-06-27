using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APIPayment.Domain.Entities
{
    public class Demand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Quant { get; set; }
        public double Value { get; set; }
    }
}
