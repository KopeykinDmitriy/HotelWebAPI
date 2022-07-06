using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Application.Interfaces;
using Hotel.Application.Common.Exceptions;
using Hotel.Domain;

namespace Hotel.Application.Humans.Commands.DeleteHuman
{
    public class DeleteHumanCommandHandler : IRequestHandler<DeleteHumanCommand>
    {
        private readonly IHotelDbContext _dbcontext;
        public DeleteHumanCommandHandler(IHotelDbContext dbContext) =>
            _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteHumanCommand request, CancellationToken cancellationtoken)
        {
            var entity = await _dbcontext.Humans.FindAsync(new object[] { request.HumanId }, cancellationtoken);
            if (entity == null || entity.HumanId != request.HumanId)
            {
                throw new NotFoundException(nameof(Human), request.HumanId);
            }

            _dbcontext.Humans.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationtoken);
            return Unit.Value;
        }
    }
}
