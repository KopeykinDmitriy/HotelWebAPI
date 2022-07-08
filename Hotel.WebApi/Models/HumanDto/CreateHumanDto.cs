using AutoMapper;
using Hotel.Application.Common.Mappings;
using Hotel.Application.Humans.Commands.CreateHuman;
using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApi.Models.HumanDto
{
    public class CreateHumanDto : IMapWith<CreateHumanCommand>
    {
        [Required]
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHumanDto, CreateHumanCommand>()
                .ForMember(humanCommand => humanCommand.Surname,
                opt => opt.MapFrom(humanDto => humanDto.Surname))
                .ForMember(humanCommand => humanCommand.FirstName,
                opt => opt.MapFrom(humanDto => humanDto.FirstName))
                .ForMember(humanCommand => humanCommand.MiddleName,
                opt => opt.MapFrom(humanDto => humanDto.MiddleName))
                .ForMember(humanCommand => humanCommand.PhoneNumber,
                opt => opt.MapFrom(humanDto => humanDto.PhoneNumber))
                .ForMember(humanCommand => humanCommand.Email,
                opt => opt.MapFrom(humanDto => humanDto.Email));
        }
    }
}
