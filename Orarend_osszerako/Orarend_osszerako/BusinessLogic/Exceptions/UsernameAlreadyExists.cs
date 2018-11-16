using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    class UsernameAlreadyExists : Exception
    {
        public UsernameAlreadyExists()
        {
        }
        public UsernameAlreadyExists(string message)
        : base(message)
        {
        }
        public UsernameAlreadyExists(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
