using System;

namespace TX.Utilities.Exceptions
{
    public class TXException : Exception
    {
        public TXException()
        {
        }

        public TXException(string message)
            : base(message)
        {
        }

        public TXException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}