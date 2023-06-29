using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIPayment.Domain.Contracts
{
        public interface IRepository<TEntity> 
    {
        Task Insert(TEntity entity);
    }
}
