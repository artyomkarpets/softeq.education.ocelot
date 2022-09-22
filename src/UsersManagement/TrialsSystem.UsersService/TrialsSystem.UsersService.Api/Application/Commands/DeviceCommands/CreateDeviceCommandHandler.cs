using System.Reflection.Metadata.Ecma335;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands.UserCommands;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, DeviceResponse>
    {
        public async Task<DeviceResponse> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            return new DeviceResponse();
        }
    }
}
