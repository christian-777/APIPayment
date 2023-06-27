using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository.Context
{
    public class SQLContext : ISQLContext
    {
        private readonly APIPaymentContext _client;
        private readonly List<Func<Task>> _commands;
        public SQLContext(APIPaymentContext client)
        {
            _client= client;
            _commands = new List<Func<Task>>();
        }
        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public async Task<bool> SaveChanges()
        {
            var status = true;
            using(var transaction= await _client.Database.BeginTransactionAsync())
            {

                var commandsTasks = _commands.Select(command => command());

                try
                {
                    await Task.WhenAll(commandsTasks);

                    transaction.Commit();
                }
                catch
                {
                    status = false;
                    transaction.Rollback();
                }
                
                _commands.Clear();
            }
            return status;
        }
    }
}
