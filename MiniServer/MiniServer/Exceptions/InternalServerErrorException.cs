using System;
using MiniServer.Common;

namespace MiniServer.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message) : base(message)
        {

        }
        public InternalServerErrorException() : this(GlobalConstans.DefaultInternalServerErrorException)
        {

        }
    }
}
