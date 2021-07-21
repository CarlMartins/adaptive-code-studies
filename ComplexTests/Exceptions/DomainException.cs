using System;

namespace ComplexTests.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException() : base()
        { }

        public DomainException(string message, Exception inner) : base(message, inner)
        { }
    }
}