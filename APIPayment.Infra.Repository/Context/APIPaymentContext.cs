using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIPayment.Domain.Entities;

namespace APIPayment.Infra.Repository.Context
{
    public class APIPaymentContext : DbContext 
    {
        public APIPaymentContext (DbContextOptions<APIPaymentContext> options)
            : base(options)
        {
        }

        public DbSet<APIPayment.Domain.Entities.Payment> Payment { get; set; } = default!;

        public DbSet<APIPayment.Domain.Entities.Demand>? Demand { get; set; }
    }
}
