using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Queries
{
    public class UserTaskQuery : IRequest<UserTaskResponse>
    {
        public UserTaskQuery(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; }
        public string UserId { get; }

    }
}
