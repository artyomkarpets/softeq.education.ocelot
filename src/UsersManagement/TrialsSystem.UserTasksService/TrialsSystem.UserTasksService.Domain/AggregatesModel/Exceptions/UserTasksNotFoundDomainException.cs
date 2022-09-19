using System.Runtime.Serialization;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Exceptions
{
    [Serializable]
    public class UserTasksNotFoundDomainException : Exception
    {
        public string Name { get; }

        public UserTasksNotFoundDomainException(string name)
        {
            Name = name;
        }

        public UserTasksNotFoundDomainException(string name, string? message) : base(message)
        {
            Name = name;
        }

        public UserTasksNotFoundDomainException(string name, string? message, Exception? innerException) : base(message, innerException)
        {
            Name = name;
        }

        protected UserTasksNotFoundDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}