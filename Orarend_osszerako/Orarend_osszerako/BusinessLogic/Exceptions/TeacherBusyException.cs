using System;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class TeacherBusyException : Exception
    {
        public TeacherBusyException()
        {
        }
        public TeacherBusyException(string message)
        : base(message)
        {
        }
        public TeacherBusyException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
