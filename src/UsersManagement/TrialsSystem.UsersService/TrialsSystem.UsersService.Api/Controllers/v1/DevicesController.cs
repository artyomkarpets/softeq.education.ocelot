using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands;
using TrialsSystem.UsersService.Api.Application.Commands.UserCommands;
using TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries;
using TrialsSystem.UsersService.Api.Application.Queries.UserQueries;
using TrialsSystem.UsersService.Api.Filters;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Controllers.v1
{
    [Route("api/v1/{userId}/[controller]")]
    [ServiceFilter(typeof(DeviceExceptionFilter))]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DevicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all devices by setting parameters and filters
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="skip">skip items (pagination parameters)</param>
        /// <param name="take">take items (pagination parameters)</param>
        /// <param name="sn">part of serial number  (filter)</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUsersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromQuery] int? skip = 0,
            [FromQuery] int? take = null,
            [FromQuery] string? sn = null)
        {
            var response = await _mediator.Send(new DevicesQuery(take, skip, sn));
            return Ok(response);
        }

        /// <summary>
        /// Get device by Id
        /// </summary>
        /// <param name="userId">authorized user Id</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string userId,
            [FromRoute] string id)
        {
            var response = await _mediator.Send(new DeviceQuery(userId, id));
            return Ok(response);
        }

        /// <summary>
        /// CreateAsync new  device
        /// </summary>
        /// <param name="request">CreateAsync user request model</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DeviceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromRoute] string userId, CreateDeviceRequest request)
        {
            var response = await _mediator.Send(new
                CreateDeviceCommand(
                request.SerialNumber,
                request.Model,
                userId));

            return Ok(response);

        }

        /// <summary>
        /// Update device by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(string id,
            [FromRoute] string userId, UpdateDeviceRequest request)
        {
            var response = await _mediator.Send(new
                UpdateDeviceCommand(
                    request.SerialNumber,
                    request.Model,
                    userId));

            return Ok(response);

        }

        /// <summary>
        /// Delete device by Id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _mediator.Send(new DeleteDeviceCommand(id));
            return Ok();
        }
    }
}
