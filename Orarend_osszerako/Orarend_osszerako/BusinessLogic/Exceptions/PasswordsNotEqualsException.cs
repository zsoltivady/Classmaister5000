using System;

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
            ExceptionLogger.LogException(inner);
        }
    }
}
