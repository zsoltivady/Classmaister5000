using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class CourseIdAlreadyExistsException : Exception
    {
        public CourseIdAlreadyExistsException()
        {
        }
        public CourseIdAlreadyExistsException(string message)
            : base(message)
        {
        }
        public CourseIdAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
