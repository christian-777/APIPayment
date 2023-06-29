using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIPayment.Infra.Repository.Context;
using APIPayment.Domain.Entities;
using MediatR;
using APIPayment.Domain.Contracts;
using APIPayment.Application.Commands.Payment.V1.Create;

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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostPayment(CreatePaymentCommand payment, CancellationToken cancellationToken)
        {
            await _mediator.Send(payment, cancellationToken);
            return await _unitOfWork.Commit() ? StatusCode(201) : StatusCode(503);
        }
    }
}
