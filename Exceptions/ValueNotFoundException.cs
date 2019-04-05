using System;
using System.Runtime.Serialization;

namespace MediatorPatternExample.Exceptions
{
    [Serializable]
    public sealed class ValueNotFoundException : Exception
    {
        public ValueNotFoundException(int id) : base($"Could not find value with an ID = {id}")
        {
        }

        private ValueNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
