using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using APIPayment.Domain.Contracts;
using MediatR;

namespace APIPayment.Application.Commands.Payment.V1.Create
{
    public class CreatePaymentCommand : IRequest<Guid>
    {
        public string? CPF { get; set; }
        public string? PaymentForm { get; set; }
        public double Value { get; set; }
    }
}
