using System.Reflection.Metadata.Ecma335;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return new UpdateUserResponse();
        }
    }
}
