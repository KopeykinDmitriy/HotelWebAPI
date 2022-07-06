using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Hotel.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Humans.Queries.GetHumanList
{
    public class GetHumanListQueryHandler : IRequestHandler<GetHumanListQuery, HumanListVm>
    {
        private readonly IHotelDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetHumanListQueryHandler(IHotelDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<HumanListVm> Handle(GetHumanListQuery request, CancellationToken cancellationtoken)
        {
            var humansQuery = await _dbcontext.Humans
                .ProjectTo<HumanLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationtoken);
            return new HumanListVm { Humans = humansQuery };
        }
    }
}
