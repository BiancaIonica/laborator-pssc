using System;
using System.Runtime.Serialization;

namespace Tema.Domain
{
    [Serializable]
    internal class InvalidProductException : Exception
    {
        public InvalidProductException()
        {
        }

        public InvalidProductException(string? message) : base(message)
        {
        }

        public InvalidProductException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}