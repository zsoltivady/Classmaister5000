using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orarend_osszerako.BusinessLogic.Exceptions
{
    public class PasswordsNotEqualsException : Exception
    {
        public PasswordsNotEqualsException()
        {
        }
        public PasswordsNotEqualsException(string message)
        : base(message)
        {
        }
        public PasswordsNotEqualsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
