using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Hotel.Application.Common.Mappings;
using Hotel.Domain;

namespace Hotel.Application.Rooms.Queries.GetRoomList
{
    public class RoomLookupDto : IMapWith<Room>
    {
        public int RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public int RoomPlaces { get; set; }
        public int RoomPriceDefault { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, RoomLookupDto>()
                .ForMember(roomDto => roomDto.RoomNumber,
                opt => opt.MapFrom(room => room.RoomNumber))
                .ForMember(roomDto => roomDto.RoomFloor,
                opt => opt.MapFrom(room => room.RoomFloor))
                .ForMember(roomDto => roomDto.RoomPlaces,
                opt => opt.MapFrom(room => room.RoomPlaces))
                .ForMember(roomDto => roomDto.RoomPriceDefault,
                opt => opt.MapFrom(room => room.RoomPriceDefault));
        }
    }
}
