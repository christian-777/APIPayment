using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Repositories;
using AutoMapper;
using MediatR;

namespace APIPayment.Application.Commands.Payment.V1.Create
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>, IMediaTRDependencyInjection
    {
        private readonly IRepository<Domain.Entities.Payment> _repository;
        private readonly IPaymentFactory _factory;
        private readonly IMapper _mapper;
        private readonly Strategy _strategy;

        public CreatePaymentCommandHandler(IRepository<Domain.Entities.Payment> repository,  IPaymentFactory factory, IMapper mapper, Strategy strategy)
        {
            _repository = repository;
            _factory = factory;
            _mapper = mapper;
            _strategy = strategy;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var strategy = _factory.GetStrategy(request.PaymentForm);

            var value = _strategy.ExecutePayment(strategy, request.Value);
            request.Value = value;

            request.PaymentForm = request.PaymentForm.ToUpper();

            var payment = _mapper.Map<Domain.Entities.Payment>(request);

            await _repository.Insert(payment);

            return payment.Id;
        }
    }
}
