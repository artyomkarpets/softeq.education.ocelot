using MediatR;
using TrialsSystem.UsersService.Api.Application.Queries.UserQueries;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DeviceQueryHandler : IRequestHandler<DeviceQuery, DeviceResponse>
    {
        public DeviceQueryHandler()
        {

        }

        public async Task<DeviceResponse> Handle(DeviceQuery request, CancellationToken cancellationToken)
        {
            return new DeviceResponse();
        }
    }
}
