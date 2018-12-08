using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class UsernameAlreadyExistsException : Exception
    {
        public UsernameAlreadyExistsException()
        {
        }
        public UsernameAlreadyExistsException(string message)
        : base(message)
        {
        }
        public UsernameAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
            
        }
    }
}
