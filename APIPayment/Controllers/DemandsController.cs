using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPayment.Infra.Repository.Data;
using APIPayment.Domain.Entities;
using APIPayment.Domain.Commands.Demand.V1.Create;
using MediatR;
using APIPayment.Domain.Contracts;

namespace APIPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public DemandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> PostDemand(CreateDemandCommand demand, CancellationToken cancellationToken)
        {
            var demandid=_mediator.Send(demand, cancellationToken);

            return _unitOfWork.Commit().Result ? Created("", demandid) : StatusCode(503);
        }
    }
}
