using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Hotel.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Common.Exceptions;
using Hotel.Domain;

namespace Hotel.Application.Humans.Commands.UpdateHuman
{
    public class UpdateHumanCommandHandler : IRequestHandler<UpdateHumanCommand>
    {
        private readonly IHotelDbContext _dbContext;
        public UpdateHumanCommandHandler(IHotelDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateHumanCommand request, CancellationToken cancellationtoken)
        {
            var entity = await _dbContext.Humans.FirstOrDefaultAsync(human =>
            human.HumanId == request.HumanId, cancellationtoken);

            if (entity==null || entity.HumanId != request.HumanId)
                throw new NotFoundException(nameof(Human), request.HumanId);

            entity.Surname = request.Surname;
            entity.FirstName = request.FirstName;
            entity.MiddleName = request.MiddleName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;

            await _dbContext.SaveChangesAsync(cancellationtoken);

            return Unit.Value;
        }
    }
}
