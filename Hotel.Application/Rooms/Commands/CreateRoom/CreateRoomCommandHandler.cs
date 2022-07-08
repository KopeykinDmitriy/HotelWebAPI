using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Domain;
using Hotel.Application.Interfaces;

namespace Hotel.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
    {
        private readonly IHotelDbContext _dbcontext;
        public CreateRoomCommandHandler(IHotelDbContext dbContext) =>
            _dbcontext = dbContext;
        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationtoken)
        {
            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                RoomFloor = request.RoomFloor,
                RoomPlaces = request.RoomPlaces,
                RoomPriceDefault = request.RoomPriceDefault,
                RoomId = Guid.NewGuid()
            };

            await _dbcontext.Rooms.AddAsync(room, cancellationtoken);
            await _dbcontext.SaveChangesAsync(cancellationtoken);
            return room.RoomId;
        }
    }
}
