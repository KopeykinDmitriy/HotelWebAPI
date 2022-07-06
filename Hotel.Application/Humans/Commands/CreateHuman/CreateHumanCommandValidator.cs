using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Humans.Commands.CreateHuman
{
    public class CreateHumanCommandValidator : AbstractValidator<CreateHumanCommand>
    {
        public CreateHumanCommandValidator()
        {
            RuleFor(createHumanCommand =>
            createHumanCommand.Surname).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.FirstName).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.Birth).NotEmpty();
            RuleFor(createHumanCommand =>
            createHumanCommand.PhoneNumber).NotEmpty();
        }
    }
}
