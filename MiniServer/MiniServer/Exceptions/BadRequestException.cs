using System;
using MiniServer.Common;

namespace MiniServer.Exceptions
{
    public class BadRequestException : Exception
    { 
        public BadRequestException(string message) : base(message)
        {

        }
        public BadRequestException(): this(GlobalConstans.DefaultBadRequestMessage)
        {

        }
    }
}
