using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Entities;

namespace APIPayment.Domain.Contracts
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
