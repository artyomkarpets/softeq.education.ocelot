using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Api.Application.Queries.CityQueries;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IdNameDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(
                new CitiesQuery());
            return Ok(response);

        }
    }
}