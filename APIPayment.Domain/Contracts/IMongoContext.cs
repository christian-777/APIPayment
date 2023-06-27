using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPayment.Domain.Contracts
{
    public interface IMongoContext
    {
        void AddCommand(Func<Task> func);
        Task<bool> SaveChanges();
    }
}
