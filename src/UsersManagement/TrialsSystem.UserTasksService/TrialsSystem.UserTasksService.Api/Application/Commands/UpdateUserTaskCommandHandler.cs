using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, UserTaskResponse>
    {
        public UpdateUserTaskCommandHandler()
        {

        }

        public async Task<UserTaskResponse> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            return new UserTaskResponse();
        }
    }
}
