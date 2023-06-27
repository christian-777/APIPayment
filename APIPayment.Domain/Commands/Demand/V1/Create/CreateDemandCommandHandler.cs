using APIPayment.Domain.Contracts;
using AutoMapper;
using MediatR;

namespace APIPayment.Domain.Commands.Demand.V1.Create
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, Guid>, IMediaTRDependencyInjection
    {
        private IRepository<Entities.Demand> _repository;
        private IMapper _mapper;

        public CreateDemandCommandHandler(IRepository<Entities.Demand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {

            var demand = _mapper.Map<Entities.Demand>(request);
            await _repository.Insert(demand);
            return demand.Id;

        }
    }
}
