using APIPayment.Domain.Contracts;
using APIPayment.Infra.Repository.Repositories;
using AutoMapper;
using MediatR;

namespace APIPayment.Application.Commands.Demand.V1.Create
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, Guid>, IMediaTRDependencyInjection
    {
        private readonly IRepository<Domain.Entities.Demand> _repository;
        private readonly IMapper _mapper;

        public CreateDemandCommandHandler(IRepository<Domain.Entities.Demand> repository, IMapper mapper)
        {
            _repository = repository;          
            _mapper = mapper;
        
        }

        public async Task<Guid> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {

            var demand = _mapper.Map<Domain.Entities.Demand>(request);
            await _repository.Insert(demand);
            return demand.Id;
            //return await Task.Run(() => Guid.NewGuid());
        }
    }
}
