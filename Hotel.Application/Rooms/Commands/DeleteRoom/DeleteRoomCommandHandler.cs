using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Application.Interfaces;
using Hotel.Application.Common.Exceptions;
using Hotel.Domain;

namespace Hotel.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IHotelDbContext _dbcontext;
        public DeleteRoomCommandHandler(IHotelDbContext dbContext) =>
            _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationtoken)
        {
            var entity = await _dbcontext.Rooms.FindAsync(new object[] { request.RoomId }, cancellationtoken);
            if (entity == null || entity.RoomId != request.RoomId)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            _dbcontext.Rooms.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationtoken);
            return Unit.Value;
        }
    }
}
