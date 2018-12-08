using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class CourseCollisionException : Exception
    {
        public CourseCollisionException()
        {
        }
        public CourseCollisionException(string message)
        : base(message)
        {
        }
        public CourseCollisionException(string message, Exception inner)
            : base(message, inner)
        {
            ExceptionLogger.LogException(inner);
        }
    }
}
