using System.Runtime.Serialization;

namespace TrialsSystem.IdentityService.Infrastructure.Exceptions
{
    [Serializable]
    internal class UsersGatewayServiceException : Exception
    {
        private HttpRequestMessage? requestMessage;

        public UsersGatewayServiceException()
        {
        }

        public UsersGatewayServiceException(HttpRequestMessage? requestMessage)
        {
            this.requestMessage = requestMessage;
        }

        public UsersGatewayServiceException(string? message) : base(message)
        {
        }

        public UsersGatewayServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UsersGatewayServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}