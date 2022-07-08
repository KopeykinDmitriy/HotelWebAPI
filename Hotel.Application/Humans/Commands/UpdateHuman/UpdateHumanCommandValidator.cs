using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Humans.Commands.UpdateHuman
{
    public class UpdateHumanCommandValidator : AbstractValidator<UpdateHumanCommand>
    {
        public UpdateHumanCommandValidator()
        {
            RuleFor(updateHumanCommand =>
            updateHumanCommand.Surname).NotEmpty();
            RuleFor(updateHumanCommand =>
            updateHumanCommand.FirstName).NotEmpty();
            RuleFor(updateHumanCommand =>
            updateHumanCommand.PhoneNumber).NotEmpty();
            RuleFor(updateHumanCommand =>
            updateHumanCommand.HumanId).NotEqual(Guid.Empty);
        }
    }
}
