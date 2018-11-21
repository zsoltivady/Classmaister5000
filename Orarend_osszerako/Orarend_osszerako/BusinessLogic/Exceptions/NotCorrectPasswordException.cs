using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class NotCorrectPasswordException : Exception
    {
        public NotCorrectPasswordException()
        {
        }
        public NotCorrectPasswordException(string message)
        : base(message)
        {
        }
        public NotCorrectPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
