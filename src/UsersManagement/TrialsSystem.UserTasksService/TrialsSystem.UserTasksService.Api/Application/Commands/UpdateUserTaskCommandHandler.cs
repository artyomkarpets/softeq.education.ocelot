using AutoMapper;
using MediatR;
using TrialsSystem.UserTasksService.Domain.AggregatesModel.UserTasksAggregate;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, UserTaskResponse>
    {
        private readonly IUserTaskRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserTaskCommandHandler(IUserTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserTaskResponse> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByNameAsync(request.Name, request.UserId);

            task.SetStatus(request.Status);

            task.AdditionalProperties.Clear();

            foreach (var prop in request.AdditionalProperties)
            {
                task.AddAdditionalProperty(prop.Key, prop.Value);
            }

            var newTask = await _repository.UpdateeAsync(task);

            return _mapper.Map<UserTaskResponse>(newTask);
        }
    }
}
