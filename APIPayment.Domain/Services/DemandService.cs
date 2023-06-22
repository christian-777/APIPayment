using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using APIPayment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Domain.Services
{
    public class DemandService
    {
        private IDemandRepository _repository;

        public DemandService(IDemandRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult<Demand>> Handler(Demand demand)
        {
            try
            {
                await _repository.Insert(demand);
                return demand;
            }
            catch
            {
                return new BadRequestObjectResult("Pedido invalido");
            }
        }
    }
}
