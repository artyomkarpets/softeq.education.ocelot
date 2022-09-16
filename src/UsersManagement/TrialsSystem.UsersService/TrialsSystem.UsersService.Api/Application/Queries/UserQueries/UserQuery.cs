using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UserQueries
{
    public class UserQuery : IRequest<GetUserResponse>
    {
        public UserQuery(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; }
        public string UserId { get; }

    }
}
