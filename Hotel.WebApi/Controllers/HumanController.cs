using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Humans.Queries.GetHumanList;
using AutoMapper;
using Hotel.Application.Humans.Commands.CreateHuman;
using Hotel.Application.Humans.Commands.UpdateHuman;
using Hotel.Application.Humans.Commands.DeleteHuman;
using Hotel.WebApi.Models.HumanDto;

namespace Hotel.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HumanController : BaseController
    {
        private readonly IMapper _mapper;
        public HumanController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of humans
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /human
        /// </remarks>
        /// <returns>Returns HumanListVm</returns>
        [HttpGet]
        public async Task<ActionResult<HumanListVm>> GetAll()
        {
            var query = new GetHumanListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the human
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /human
        /// {
        ///     surname: "human surname",
        ///     firstname: "human firstname",
        ///     middlename: "human middlename",
        ///     phonenumber: "89899574319",
        ///     email: "humanemail@gmail.com"
        /// }
        /// </remarks>
        /// <param name="createHumanDto">CreateHumanDto object</param>
        /// <returns>Returns id (guid)</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHumanDto createHumanDto)
        {
            var command = _mapper.Map<CreateHumanCommand>(createHumanDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }

        /// <summary>
        /// Updates the human
        /// </summary>
        /// <remarks>
        /// PUT /human/{HumanId}
        /// {
        ///     surname: "updated human surname"
        /// }
        /// </remarks>
        /// <param name="updateHumanDto">UpdateHumanDto object</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHumanDto updateHumanDto)
        {
            var command = _mapper.Map<UpdateHumanCommand>(updateHumanDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid humanId)
        {
            var command = new DeleteHumanCommand
            {
                HumanId = humanId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
