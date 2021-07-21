using System;

namespace ComplexTests.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException() : base()
        { }

        public ServiceException(string message, Exception inner) : base(message, inner)
        { }
    }
}