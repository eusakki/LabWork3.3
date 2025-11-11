using System;

namespace BLL.Exceptions
{
    public class StudIdException : Exception
    {
        public StudIdException() : base() { }
        public StudIdException(string message) : base(message) { }
        public StudIdException(string message, Exception inner) : base(message, inner) { }
    }
}
