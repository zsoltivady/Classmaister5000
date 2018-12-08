using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
