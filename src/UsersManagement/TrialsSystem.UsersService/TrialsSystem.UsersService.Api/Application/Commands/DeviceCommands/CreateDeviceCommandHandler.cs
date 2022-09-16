using System.Reflection.Metadata.Ecma335;
using MediatR;
using TrialsSystem.UsersService.Api.Application.Commands.UserCommands;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return new CreateUserResponse();
        }
    }
}
