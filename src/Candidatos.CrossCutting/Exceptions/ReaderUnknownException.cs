using System;
using System.Runtime.Serialization;

namespace Candidatos.CrossCutting.Exceptions
{
    [Serializable]
    public class ReaderUnknownException : Exception
    {
        public ReaderUnknownException()
        {
        }

        public ReaderUnknownException(string message) : base(message)
        {
        }

        public ReaderUnknownException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReaderUnknownException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
