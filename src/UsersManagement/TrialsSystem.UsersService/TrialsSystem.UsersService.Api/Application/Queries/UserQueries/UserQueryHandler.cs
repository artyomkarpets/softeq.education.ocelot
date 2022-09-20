using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UserQueries
{
    public class UserQueryHandler : IRequestHandler<UserQuery, GetUserResponse>
    {
        private readonly IUserRepository _repository;

        public UserQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserResponse> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return new GetUserResponse();
        }
    }
}
