using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hotel.Application.Rooms.Queries.GetRoomList
{
    public class GetRoomListQuery : IRequest<RoomListVm>
    {
    }
}
