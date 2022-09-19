using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, UserTaskResponse>
    {
        public async Task<UserTaskResponse> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            return new UserTaskResponse();
        }
    }
}
