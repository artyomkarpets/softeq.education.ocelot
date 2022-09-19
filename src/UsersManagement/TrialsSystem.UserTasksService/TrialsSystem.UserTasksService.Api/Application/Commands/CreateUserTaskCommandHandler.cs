using MediatR;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, string>
    {
        private readonly IUserTaskRepository _repository;

        public CreateUserTaskCommandHandler(IUserTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new UserTask(request.UserId, request.Name);

            foreach (var prop in request.AdditionalProperties)
            {
                task.AddAdditionalProperty(prop.Key, prop.Value);
            }

            return await _repository.CreateAsync(task);
        }
    }
}
