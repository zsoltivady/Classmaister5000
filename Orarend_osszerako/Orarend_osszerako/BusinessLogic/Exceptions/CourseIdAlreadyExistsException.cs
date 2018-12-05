using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
