using MediatR;
using TrialsSystem.UserTasksService.Infrastructure.Models;

namespace TrialsSystem.UserTasksService.Api.Application.Queries
{
    public class UserTaskQueryHandler : IRequestHandler<UserTaskQuery, UserTaskResponse>
    {
        public async Task<UserTaskResponse> Handle(UserTaskQuery request, CancellationToken cancellationToken)
        {
            return new UserTaskResponse();
        }
    }
}
