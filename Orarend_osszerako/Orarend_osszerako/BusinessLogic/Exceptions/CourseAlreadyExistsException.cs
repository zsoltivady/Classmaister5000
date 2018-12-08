using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class CourseAlreadyExistsException : Exception
    {
        public CourseAlreadyExistsException()
        {
        }
        public CourseAlreadyExistsException(string message)
        : base(message)
        {
        }
        public CourseAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    } 
}