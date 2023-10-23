using System;

namespace CA_Week5_4.Exps
{
    internal class NoValidEmployeeException : Exception
    {
        public NoValidEmployeeException(string msg) : base(msg) { }
    }
}
