using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class SubjectNotExistsException : Exception
    {
        public SubjectNotExistsException()
        {
        }
        public SubjectNotExistsException(string message)
        : base(message)
        {
        }
        public SubjectNotExistsException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
