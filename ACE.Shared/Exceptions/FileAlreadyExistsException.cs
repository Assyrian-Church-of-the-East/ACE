using System;

namespace Isg.Shared.Exceptions
{
    public class FileAlreadyExistsException : Exception
    {
        public FileAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
