using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommand : IRequest
    {
        public DeleteDeviceCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
