using APIPayment.Domain.Contracts;
using MediatR;

namespace APIPayment.Application.Commands.Demand.V1.Create
{
    public class CreateDemandCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Quant { get; set; }
        public double? Value { get; set; }
    }
}
