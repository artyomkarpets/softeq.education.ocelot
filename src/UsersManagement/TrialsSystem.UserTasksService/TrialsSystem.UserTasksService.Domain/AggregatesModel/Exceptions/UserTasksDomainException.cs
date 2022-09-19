using System.Runtime.Serialization;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Exceptions
{
    [Serializable]
    public class UserTasksDomainException : Exception
    {
        public string Name { get; }


        public UserTasksDomainException(string name)
        {
            Name = name;
        }

        public UserTasksDomainException(string name, string? message) : base(message)
        {
            Name = name;
        }

        public UserTasksDomainException(string name, string? message, Exception? innerException) : base(message, innerException)
        {
            Name = name;
        }

        protected UserTasksDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}