using System;
using System.Runtime.Serialization;

namespace MediatorPatternExample.Exceptions
{
    [Serializable]
    public sealed class InvalidCommandException : Exception
    {
        public InvalidCommandException(params string[] errorMessages) : base(string.Join(Environment.NewLine, errorMessages))
        {
        }

        private InvalidCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
