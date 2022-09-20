using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands;
using TrialsSystem.UsersService.Api.Application.Commands.UserCommands;
using TrialsSystem.UsersService.Api.Application.Queries.UserQueries;
using TrialsSystem.UsersService.Api.Filters;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    /// <summary>
    /// User management controller
    /// </summary>
    [Route("api/v1/{userId}/[controller]")]
    [ServiceFilter(typeof(UserExceptionFilter))]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all users by setting parameters and filters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <param name="email">part of sn (filter)</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUsersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 20,
            [FromQuery] string? email = null,
            [FromQuery] string? name = null,
            [FromQuery] string? surname = null)
        {
            var response = await _mediator.Send(
                new UsersQuery(take, skip, email, name, surname));
            return Ok(response);
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            var response = await _mediator.Send(new UserQuery(userId, id));
            return Ok(response);
        }

        /// <summary>
        /// CreateAsync new  user
        /// </summary>
        /// <param name="request">CreateAsync user request model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromRoute] string userId, CreateUserRequest request)
        {
            var response = await _mediator.Send(new
                CreateUserCommand(
                request.Email,
                request.Name,
                request.Surname,
                request.CityId,
                request.BirthDate,
                request.Weight,
                request.Height,
                request.GenderId,
                userId));

            return Ok(response);

        }

        /// <summary>
        /// Update user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(string id,
            [FromRoute] string userId, UpdateUserRequest request)
        {
            var response = await _mediator.Send(new
                UpdateUserCommand(id,
                request.Name,
                request.Surname,
                request.CityId,
                request.BirthDate,
                request.Weight,
                request.Height,
                request.GenderId,
                userId));

            return Ok(response);
        }

        /// <summary>
        /// Delete user by Id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}
