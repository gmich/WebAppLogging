using System;

namespace Infrastructure.Logging
{
    public class SomethingWentWrongException : ApplicationSpecificException
    {
        public SomethingWentWrongException()
        {
        }

        public SomethingWentWrongException(string message)
            : base(message)
        {
        }

        public SomethingWentWrongException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
