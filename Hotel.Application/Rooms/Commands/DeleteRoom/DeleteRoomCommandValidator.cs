using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Rooms.Commands.DeleteRoom
{
    public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
    {
        public DeleteRoomCommandValidator()
        {
            RuleFor(deleteRoomCommand =>
            deleteRoomCommand.RoomId).NotEqual(Guid.Empty);
        }
    }
}
