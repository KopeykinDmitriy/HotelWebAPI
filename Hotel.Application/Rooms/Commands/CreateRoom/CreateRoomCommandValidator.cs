using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Rooms.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(createRoomCommand =>
            createRoomCommand.RoomNumber).NotEmpty();
            RuleFor(createRoomCommand =>
            createRoomCommand.RoomFloor).NotEmpty();
            RuleFor(createRoomCommand =>
            createRoomCommand.RoomPlaces).NotEmpty();
            RuleFor(createRoomCommand =>
            createRoomCommand.RoomPriceDefault).NotEmpty();
        }
    }
}
