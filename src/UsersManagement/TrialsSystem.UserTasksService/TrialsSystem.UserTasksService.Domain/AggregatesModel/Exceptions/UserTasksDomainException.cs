using System.Runtime.Serialization;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Exceptions
{
    [Serializable]
    internal class UserTasksDomainException : Exception
    {
        public UserTasksDomainException()
        {
        }

        public UserTasksDomainException(string? message) : base(message)
        {
        }

        public UserTasksDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserTasksDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}