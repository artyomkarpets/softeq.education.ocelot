using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Queries
{
    public class UserTasksQuery : IRequest<IEnumerable<UserTaskResponse>>
    {
        public UserTasksQuery(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public string UserId { get; set; }

        public string Name { get; set; }
    }
}
