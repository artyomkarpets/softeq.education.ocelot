using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDtos;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DeviceQuery : IRequest<DeviceResponse>
    {
        public DeviceQuery(string id, string userId)
        {
            Id = id;
            UserId = userId;
        }

        public string Id { get; }
        public string UserId { get; }

    }
}
