using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class EntityAlreadyExistException : Exception
    {
        public string PublicMessage { get; }

        public int ReturnStatusCode { get; }

        public EntityAlreadyExistException()
        {
        }


        public EntityAlreadyExistException(string message, string publicMessage, int returnStatusCode = StatusCodes.Status409Conflict) : base(message)
        {
            PublicMessage = publicMessage;
            ReturnStatusCode = returnStatusCode;
        }

        public EntityAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}