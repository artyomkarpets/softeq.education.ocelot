using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
