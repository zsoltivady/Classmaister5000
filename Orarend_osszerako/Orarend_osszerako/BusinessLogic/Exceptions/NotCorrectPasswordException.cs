using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class NotCorrectPasswordException : Exception
    {
        public NotCorrectPasswordException()
        {
        }
        public NotCorrectPasswordException(string message)
        : base(message)
        {
        }
        public NotCorrectPasswordException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
