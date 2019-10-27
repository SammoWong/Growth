using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Exceptions
{
    public class KnownException : Exception
    {
        public KnownException(string message) : base(message)
        {

        }

        public KnownException(int code, string message) : base(message)
        {
            Code = code;
        }

        public int Code { get; set; }
    }
}
