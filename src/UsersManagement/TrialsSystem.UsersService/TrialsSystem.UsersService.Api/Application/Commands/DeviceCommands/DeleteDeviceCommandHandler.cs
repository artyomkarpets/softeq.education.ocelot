using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
    {
        public DeleteDeviceCommandHandler()
        {

        }

        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
