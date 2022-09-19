using MediatR;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand>
    {
        private readonly IUserTaskRepository _repository;
        public DeleteUserTaskCommandHandler(IUserTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteByNameAsync(request.AuthorizedUserId, request.Name);

            return Unit.Value;
        }
    }
}
