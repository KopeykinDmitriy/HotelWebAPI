using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hotel.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomFloor { get; set; }
        public int RoomPlaces { get; set; }
        public int RoomPriceDefault { get; set; }
    }
}
