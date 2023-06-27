using APIPayment.Domain.Commands.Demand.V1.Create;
using APIPayment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandsController : ControllerBase
    {
        private readonly CreateDemandCommandHandler _demandService;
        private readonly IMediator _mediator;

        public DemandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "Insert Demand")]
        public Task<Guid> InsertDemand([FromBody] CreateDemandCommand demand, CancellationToken cancellationToken)
        {
            return _mediator.Send(demand, cancellationToken);
        }
    }
}
