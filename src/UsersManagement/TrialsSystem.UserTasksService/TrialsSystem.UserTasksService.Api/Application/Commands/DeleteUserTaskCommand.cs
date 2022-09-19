using MediatR;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class DeleteUserTaskCommand : IRequest
    {
        public DeleteUserTaskCommand(string name, string authorizedUserId)
        {
            Name = name;
            AuthorizedUserId = authorizedUserId;
        }

        public string Name { get; }
        public string AuthorizedUserId { get; }

    }
}
