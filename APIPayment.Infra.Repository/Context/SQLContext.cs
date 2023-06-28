using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository.Context
{
    public class SQLContext : DbContext, ISQLContext
    {
        public SQLContext(DbContextOptions options): base(options)
        {
        }

        public async Task<bool> SaveChanges()
        {
            bool stt = true;
            try
            {
                await base.SaveChangesAsync();
            }
            catch
            {
                stt = false;
            } 
            return stt;
        }
    }
}
