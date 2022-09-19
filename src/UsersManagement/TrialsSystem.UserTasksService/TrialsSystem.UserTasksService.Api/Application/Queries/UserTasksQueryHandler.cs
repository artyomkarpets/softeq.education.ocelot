using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Queries
{
    public class UserTasksQueryHandler : IRequestHandler<UserTasksQuery, IEnumerable<UserTaskResponse>>
    {
        public async Task<IEnumerable<UserTaskResponse>> Handle(UserTasksQuery request, CancellationToken cancellationToken)
        {
            return new List<UserTaskResponse>();
        }
    }
}
