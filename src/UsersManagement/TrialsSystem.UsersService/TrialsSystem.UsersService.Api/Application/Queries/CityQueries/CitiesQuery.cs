using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialSystem.Shared.UsersService.Models;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CitiesQuery : IRequest<IEnumerable<IdNameDto>>
    {
    }
}
