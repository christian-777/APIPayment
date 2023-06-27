using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIPayment.Domain.Commands.Demand.V1.Create;
using AutoMapper;

namespace APIPayment.Domain.Commands.Payment.V1.Create
{
    public class CreatePaymentCommandProfile : Profile
    {
        public CreatePaymentCommandProfile()
        {
            CreateMap<CreatePaymentCommand, Entities.Payment>().ForMember(output => output.Id, option => option.MapFrom(input => Guid.NewGuid()));
        }
    }
}
