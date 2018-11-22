using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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