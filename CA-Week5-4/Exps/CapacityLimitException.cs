using System;

namespace CA_Week5_4.Exps
{
    internal class CapacityLimitException : Exception
    {
        public CapacityLimitException(string msg) : base(msg) { }
    }
}
