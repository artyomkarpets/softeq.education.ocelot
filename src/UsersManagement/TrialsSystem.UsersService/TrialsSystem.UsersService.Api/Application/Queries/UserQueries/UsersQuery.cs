using System.Globalization;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UserQueries
{
    public class UsersQuery : IRequest<IEnumerable<GetUsersResponse>>
    {
        public int Take { get; }

        public int Skip { get; }

        public string? Email { get; }
        public string? Name { get; }
        public string? Surname { get; }

        public UsersQuery(int take, int skip, string email, string name, string surname)
        {
            Take = take;
            Skip = skip;
            Email = email;
            Name = name;
            Surname = surname;
        }
    }
}
