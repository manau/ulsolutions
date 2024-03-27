using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ULSolutions.Application.Commands;
using ULSolutions.API;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] InputStringModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new CalculateCommand { Expression = input.InputString };
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
