using APIPayment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using APIPayment.Domain.Commands.Payment.V1.Create;
using MediatR;
using APIPayment.Domain.Contracts;
using System.Net;

namespace APIPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentsController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpPost(Name = "Insert Payment")]
        public ActionResult<Guid> InsertPayment([FromBody] CreatePaymentCommand payment, CancellationToken cancellationToken)
        {
            var aux=_mediator.Send(payment, cancellationToken);
            _mediator.Send(payment, cancellationToken);

            if (_unitOfWork.Commit().Result)
                return Created("", aux);
            else
                return StatusCode(503);
        }
    }
}
