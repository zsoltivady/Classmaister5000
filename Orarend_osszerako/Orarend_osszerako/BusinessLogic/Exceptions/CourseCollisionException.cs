using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
