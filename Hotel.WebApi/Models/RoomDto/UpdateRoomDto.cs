using AutoMapper;
using Hotel.Application.Common.Mappings;
using Hotel.Application.Rooms.Commands.UpdateRoom;

namespace Hotel.WebApi.Models.RoomDto
{
    public class UpdateRoomDto : IMapWith<UpdateRoomCommand>
    {
        public string RoomNumber { get; set; }
        public string RoomFloor { get; set; }
        public string RoomPlaces { get; set; }
        public string RoomPriceDefault { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateRoomDto, UpdateRoomCommand>()
                .ForMember(roomCommand => roomCommand.RoomNumber,
                opt => opt.MapFrom(roomDto => roomDto.RoomNumber))
                .ForMember(roomCommand => roomCommand.RoomFloor,
                opt => opt.MapFrom(roomDto => roomDto.RoomFloor))
                .ForMember(roomCommand => roomCommand.RoomPlaces,
                opt => opt.MapFrom(roomDto => roomDto.RoomPlaces))
                .ForMember(roomCommand => roomCommand.RoomPriceDefault,
                opt => opt.MapFrom(roomDto => roomDto.RoomPriceDefault));
        }
    }
}
