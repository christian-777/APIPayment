using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPayment.Infra.Repository.Context;
using APIPayment.Domain.Entities;
using APIPayment.Application.Commands.Demand.V1.Create;
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

        public DemandsController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;   
        }

        [HttpPost]
        public async Task<ActionResult> PostDemand(CreateDemandCommand demand, CancellationToken cancellationToken)
        {
            await _mediator.Send(demand, cancellationToken);
            return await _unitOfWork.Commit() ? StatusCode(201) : StatusCode(503);
            
        }
    }
}
