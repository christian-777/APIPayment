using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Models.Entities;

namespace APIPayment.Models.Contracts
{
    public interface IRepository
    {
        Task<Payment> InsertPayment(Payment payment);
        Task<IEnumerable<Payment>> ListPayments();
    }
}
