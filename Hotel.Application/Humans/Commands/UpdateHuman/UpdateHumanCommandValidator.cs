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
            RuleFor(createHumanCommand =>
            createHumanCommand.Surname).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.FirstName).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.PhoneNumber).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.HumanId).NotEqual(Guid.Empty);
        }
    }
}
