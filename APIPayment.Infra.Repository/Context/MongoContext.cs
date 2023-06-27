using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contracts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APIPayment.Infra.Repository.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoClient _client;
        private readonly List<Func<Task>> _commands;
        public MongoContext(IMongoClient client)
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
            using(var session= await _client.StartSessionAsync())
            {

                var commandsTasks = _commands.Select(command => command());

                try
                {
                    await Task.WhenAll(commandsTasks);
                }
                catch
                {
                    status = false;
 
                }
                
                _commands.Clear();
            }
            return status;
        }
    }
}
