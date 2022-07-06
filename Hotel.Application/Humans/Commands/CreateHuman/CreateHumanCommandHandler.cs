using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Domain;
using Hotel.Application.Interfaces;

namespace Hotel.Application.Humans.Commands.CreateHuman
{
    public class CreateHumanCommandHandler : IRequestHandler<CreateHumanCommand, Guid>
    {
        private readonly IHotelDbContext _dbcontext;
        public CreateHumanCommandHandler(IHotelDbContext dbContext) =>
            _dbcontext = dbContext;
        public async Task<Guid> Handle(CreateHumanCommand request, CancellationToken cancellationtoken)
        {
            var human = new Human
            {
                Surname = request.Surname,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                HumanId = Guid.NewGuid()
            };

            await _dbcontext.Humans.AddAsync(human, cancellationtoken);
            await _dbcontext.SaveChangesAsync(cancellationtoken);
            return human.HumanId;
        }
    }
}
