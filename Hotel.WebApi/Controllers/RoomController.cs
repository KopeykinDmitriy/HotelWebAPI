using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Rooms.Queries.GetRoomList;
using AutoMapper;
using Hotel.Application.Rooms.Commands.CreateRoom;
using Hotel.Application.Rooms.Commands.UpdateRoom;
using Hotel.Application.Rooms.Commands.DeleteRoom;
using Hotel.WebApi.Models.RoomDto;

namespace Hotel.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoomController : BaseController
    {
        private readonly IMapper _mapper;
        public RoomController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of rooms
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /room
        /// </remarks>
        /// <returns>Returns RoomListVm</returns>
        [HttpGet]
        public async Task<ActionResult<RoomListVm>> GetAll()
        {
            var query = new GetRoomListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the room
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /room
        /// {
        ///     RoomNumber = 404,
        ///     RoomFloor = 4,
        ///     RoomPlaces = 2,
        ///     RoomPriceDefault = 2000
        /// }
        /// </remarks>
        /// <param name="createRoomDto">CreateRoomDto object</param>
        /// <returns>Returns id (guid)</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRoomDto createRoomDto)
        {
            var command = _mapper.Map<CreateRoomCommand>(createRoomDto);
            var roomId = await Mediator.Send(command);
            return Ok(roomId);
        }

        /// <summary>
        /// Updates the room
        /// </summary>
        /// <remarks>
        /// PUT /room/{RoomId}
        /// {
        ///     RoomPriceDefault: 5000
        /// }
        /// </remarks>
        /// <param name="updateRoomDto">UpdateRoomDto object</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRoomDto updateRoomDto)
        {
            var command = _mapper.Map<UpdateRoomCommand>(updateRoomDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid roomId)
        {
            var command = new DeleteRoomCommand
            {
                RoomId = roomId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
