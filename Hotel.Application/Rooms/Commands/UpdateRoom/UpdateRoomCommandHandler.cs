using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Common.Exceptions;
using Hotel.Domain;

namespace Hotel.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IHotelDbContext _dbContext;
        public UpdateRoomCommandHandler(IHotelDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationtoken)
        {
            var entity = await _dbContext.Rooms.FirstOrDefaultAsync(room =>
            room.RoomId == request.RoomId, cancellationtoken);

            if (entity == null || entity.RoomId != request.RoomId)
                throw new NotFoundException(nameof(Room), request.RoomId);

            entity.RoomNumber = request.RoomNumber;
            entity.RoomFloor = request.RoomFloor;
            entity.RoomPlaces = request.RoomPlaces;
            entity.RoomPriceDefault = request.RoomPriceDefault;

            await _dbContext.SaveChangesAsync(cancellationtoken);

            return Unit.Value;
        }
    }
}
