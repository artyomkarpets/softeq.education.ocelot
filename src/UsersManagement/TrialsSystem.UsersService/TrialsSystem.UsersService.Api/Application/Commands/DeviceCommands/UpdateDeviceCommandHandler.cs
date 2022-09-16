using System.Reflection.Metadata.Ecma335;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            return new UpdateUserResponse();
        }
    }
}
