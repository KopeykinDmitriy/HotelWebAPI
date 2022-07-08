using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hotel.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public Guid RoomId { get; set; }
    }
}
