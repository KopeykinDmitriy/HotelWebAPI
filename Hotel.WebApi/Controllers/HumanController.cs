using Microsoft.AspNetCore.Mvc;
using Hotel.Application.Humans.Queries.GetHumanList;
using AutoMapper;
using Hotel.Application.Humans.Commands.CreateHuman;
using Hotel.Application.Humans.Commands.UpdateHuman;
using Hotel.Application.Humans.Commands.DeleteHuman;
using Hotel.WebApi.Models;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HumanController : BaseController
    {
        private readonly IMapper _mapper;
        public HumanController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<HumanListVm>> GetAll()
        {
            var query = new GetHumanListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHumanDto createHumanDto)
        {
            var command = _mapper.Map<CreateHumanCommand>(createHumanDto);
            var humanId = await Mediator.Send(command);
            return Ok(humanId);
        }

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
