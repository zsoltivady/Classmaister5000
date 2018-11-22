using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class TeacherBusyExceptionException : Exception
    {
        public TeacherBusyExceptionException()
        {
        }
        public TeacherBusyExceptionException(string message)
        : base(message)
        {
        }
        public TeacherBusyExceptionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
