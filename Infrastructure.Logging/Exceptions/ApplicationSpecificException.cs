using System;

namespace Infrastructure.Logging
{
    public class ApplicationSpecificException : Exception
    {
        public ApplicationSpecificException()
        {
        }

        public ApplicationSpecificException(string message)
            : base(message)
        {
        }

        public ApplicationSpecificException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
