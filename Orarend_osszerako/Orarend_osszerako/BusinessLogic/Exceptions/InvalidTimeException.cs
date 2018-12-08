using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class InvalidTimeException : Exception
    {
        public InvalidTimeException()
        {
        }
        public InvalidTimeException(string message)
        : base(message)
        {
        }
        public InvalidTimeException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
