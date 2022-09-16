using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DevicesQuery : IRequest<IEnumerable<DeviceResponse>>
    {
        public int? Take { get; }

        public int? Skip { get; }

        public string? SN { get; }

        public DevicesQuery(int? take, int? skip, string sn)
        {
            Take = take;
            Skip = skip;
            SN = sn;
        }
    }
}
