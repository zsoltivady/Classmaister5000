using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class SubjectAlreadyExistsException : Exception
    {
        public SubjectAlreadyExistsException()
        {
        }
        public SubjectAlreadyExistsException(string message)
        : base(message)
        {
        }
        public SubjectAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
