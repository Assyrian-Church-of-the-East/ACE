using System;

namespace Isg.Shared.Exceptions
{
    /// <summary>
    /// Exception for errors during calls to  the authoring integration API.
    /// </summary>
    public class AuthoringIntegrationApiException : Exception
    {
        /// <summary>
        /// Create a new authoring integration exception
        /// </summary>
        /// <param name="message">Error message</param>
        public AuthoringIntegrationApiException(string message) : base(message)
        {
        }
    }
}
