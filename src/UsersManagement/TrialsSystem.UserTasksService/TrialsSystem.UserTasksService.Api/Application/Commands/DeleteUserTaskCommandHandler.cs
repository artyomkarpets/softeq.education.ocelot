using MediatR;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand>
    {
        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
