using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.UserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        public DeleteUserCommandHandler()
        {

        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
