using MediatR;

namespace TrialsSystem.UserTasksService.Api.Application.Commands
{
    public class DeleteUserTaskCommand : IRequest
    {
        public DeleteUserTaskCommand(string id, string authorizedUserId)
        {
            Id = id;
            AuthorizedUserId = authorizedUserId;
        }

        public string Id { get; }
        public string AuthorizedUserId { get; }

    }
}
