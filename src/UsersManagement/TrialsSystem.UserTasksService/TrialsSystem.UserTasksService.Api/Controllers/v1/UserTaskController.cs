using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel.DataAnnotations;
using TrialsSystem.UserTasksService.Api.Filters;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Controllers.v1
{
    [ServiceFilter(typeof(UserTaskExceptionFilter))]
    [Route("api/v1/{userId}/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlHelperFactory _factory;
        public UserTaskController(IMediator mediator, IUrlHelperFactory factory)
        {
            _mediator = mediator;
            _factory = factory;
        }

        /// <summary>
        /// Returns user tasks
        /// </summary>
        /// <remarks></remarks>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<UserTaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync(
            [FromRoute][Required] string userId,
            [FromQuery] string name)
        {
            return Ok();
        }

        /// <summary>
        /// Returns user specific task by id
        /// </summary>
        /// <remarks></remarks>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserTaskResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(
            [FromRoute][Required] string userId,
            [FromRoute][Required] string id)
        {

            return Ok();
        }

        /// <summary>
        /// Adds task to user
        /// </summary>
        /// <remarks>.</remarks>
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(
            [FromRoute][Required] string userId,
            [FromBody] CreateUserTaskRequest request)
        {
            var helper = _factory.GetUrlHelper(ControllerContext);
            var uri = helper.Action("Get", new { patientId = userId, id = "" });//TODO: return if of new task
            return Created(uri, null);
        }

        /// <summary>
        /// Update user task
        /// </summary>
        /// <remarks>.</remarks>
        /// <param name="request"></param>
        /// <param name="userId"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute][Required] string userId,
            [FromBody] UpdateUserTaskRequest request)
        {

            return Ok(new UserTaskResponse());
        }

    }
}
