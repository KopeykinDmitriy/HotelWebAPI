using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Hotel.Application.Humans.Commands.DeleteHuman
{
    public class DeleteHumanCommandValidator : AbstractValidator<DeleteHumanCommand>
    {
        public DeleteHumanCommandValidator()
        {
            RuleFor(deleteHumanCommand =>
            deleteHumanCommand.HumanId).NotEqual(Guid.Empty);
        }
    }
}
