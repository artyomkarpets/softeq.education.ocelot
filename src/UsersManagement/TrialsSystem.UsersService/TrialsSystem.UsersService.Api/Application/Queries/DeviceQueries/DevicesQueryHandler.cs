using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DevicesQueryHandler : IRequestHandler<DevicesQuery, IEnumerable<DeviceResponse>>
    {
        public async Task<IEnumerable<DeviceResponse>> Handle(DevicesQuery request, CancellationToken cancellationToken)
        {
            return new List<DeviceResponse>();
        }
    }
}
