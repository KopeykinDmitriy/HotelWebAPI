using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Hotel.Application.Common.Mappings;
using Hotel.Domain;

namespace Hotel.Application.Humans.Queries.GetHumanList
{
    public class HumanLookupDto : IMapWith<Human>
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateOnly Birth { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Human, HumanLookupDto>()
                .ForMember(humanDto => humanDto.Surname,
                opt => opt.MapFrom(human => human.Surname))
                .ForMember(humanDto => humanDto.FirstName,
                opt => opt.MapFrom(human => human.FirstName))
                .ForMember(humanDto => humanDto.MiddleName,
                opt => opt.MapFrom(human => human.MiddleName))
                .ForMember(humanDto => humanDto.Birth,
                opt => opt.MapFrom(human => human.Birth))
                .ForMember(humanDto => humanDto.PhoneNumber,
                opt => opt.MapFrom(human => human.PhoneNumber))
                .ForMember(humanDto => humanDto.Email,
                opt => opt.MapFrom(human => human.Email));
        }
    }
}
