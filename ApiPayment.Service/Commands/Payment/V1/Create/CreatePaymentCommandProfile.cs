using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Application.Commands.Demand.V1.Create;
using AutoMapper;

namespace APIPayment.Application.Commands.Payment.V1.Create
{
    public class CreatePaymentCommandProfile : Profile
    {
        public CreatePaymentCommandProfile()
        {
            CreateMap<CreatePaymentCommand, Domain.Entities.Payment>().ForMember(output => output.Id, option => option.MapFrom(input => Guid.NewGuid()));
        }
    }
}
