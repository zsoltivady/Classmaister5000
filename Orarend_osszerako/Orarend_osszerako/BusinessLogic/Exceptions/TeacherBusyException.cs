using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
