using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;

namespace APIPayment.Domain.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISQLContext _context;

        public UnitOfWork(ISQLContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChanges();
        }
    }
}
