using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIPayment.Domain.Commands.Payment.V1.Create
{
    public class CreatePaymentCommand : IRequest<Guid>
    {
        public string? CPF { get; set; }
        public string? PaymentForm { get; set; }
        public double Value { get; set; }
    }
}
