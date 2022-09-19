using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class CreateUserTaskCommand : IRequest<UserTaskResponse>
    {
        public CreateUserTaskCommand(string name, string userId, Dictionary<string, string> additionalProperties)
        {
            Name = name;
            UserId = userId;
            AdditionalProperties = additionalProperties;
        }

        public string Name { get; set; }

        public string UserId { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }

    }
}
