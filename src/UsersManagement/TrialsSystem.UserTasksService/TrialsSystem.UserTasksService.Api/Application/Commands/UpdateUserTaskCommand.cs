using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class UpdateUserTaskCommand : IRequest<UserTaskResponse>
    {
        public UpdateUserTaskCommand(string name, string userId, string status, Dictionary<string, string> additionalProperties)
        {
            Name = name;
            UserId = userId;
            AdditionalProperties = additionalProperties;
            Status = status;
        }

        public string Name { get; }

        public string UserId { get; }

        public string Status { get; }

        public Dictionary<string, string> AdditionalProperties { get; }

    }
}
