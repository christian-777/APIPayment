using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace APIPayment.Domain.Commands.Demand.V1.Create
{
    public class CreateDemandCommandProfile : Profile
    {
        public CreateDemandCommandProfile()
        {
            CreateMap<CreateDemandCommand, Entities.Demand>();
        }
    }
}
