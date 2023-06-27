using APIPayment.Domain.Contexts;
using APIPayment.Domain.Contracts;
using AutoMapper;
using MediatR;

namespace APIPayment.Domain.Commands.Payment.V1.Create
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>, IMediaTRDependencyInjection
    {
        private readonly StrategyContext _context;
        private IRepository<Entities.Payment> _repository;
        private IPaymentFactory _factory;
        private IMapper _mapper;

        public CreatePaymentCommandHandler(IRepository<Entities.Payment> repository, StrategyContext strategyContext, IPaymentFactory factory, IMapper mapper)
        {
            _context = strategyContext;
            _repository = repository;
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var strategy = _factory.GetStrategy(request.PaymentForm);

            var value = _context.ExecutePayment(strategy, request.Value);
            request.Value = value;

            request.PaymentForm = request.PaymentForm.ToUpper();

            var payment = _mapper.Map<Entities.Payment>(request);

            await _repository.Insert(payment);

            return payment.Id;
        }
    }
}
