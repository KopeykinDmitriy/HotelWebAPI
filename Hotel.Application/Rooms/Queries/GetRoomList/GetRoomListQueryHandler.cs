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

namespace Hotel.Application.Rooms.Queries.GetRoomList
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, RoomListVm>
    {
        private readonly IHotelDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetRoomListQueryHandler(IHotelDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public async Task<RoomListVm> Handle(GetRoomListQuery request, CancellationToken cancellationtoken)
        {
            var roomsQuery = await _dbcontext.Rooms
                .ProjectTo<RoomLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationtoken);
            return new RoomListVm { Rooms = roomsQuery };
        }
    }
}
