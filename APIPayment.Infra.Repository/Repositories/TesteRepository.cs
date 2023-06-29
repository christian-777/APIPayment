using APIPayment.Domain.Entities;
using APIPayment.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPayment.Infra.Repository.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        private readonly DbContext _context;

        public TesteRepository(DbContext context)
        {
            _context = context;
        }

        public async Task Insert(Demand demand)
        {
            var teste=_context.Set<Domain.Entities.Demand>().Add(demand);
        }
    }
}
