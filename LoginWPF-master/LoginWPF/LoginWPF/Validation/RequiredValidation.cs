using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWPF.Validation
{
    public static class Required
    {
        public static bool IsValid(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
