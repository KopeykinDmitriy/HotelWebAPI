using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Rooms.Commands.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(updateRoomCommand =>
            updateRoomCommand.RoomId).NotEqual(Guid.Empty);
            RuleFor(updateRoomCommand =>
            updateRoomCommand.RoomNumber).NotEmpty();
            RuleFor(updateRoomCommand =>
            updateRoomCommand.RoomFloor).NotEmpty();
            RuleFor(updateRoomCommand =>
            updateRoomCommand.RoomPlaces).NotEmpty();
            RuleFor(updateRoomCommand =>
            updateRoomCommand.RoomPriceDefault).NotEmpty();
        }
    }
}
