using System;
using System.Runtime.Serialization;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The Contoso service client exception.
    /// </summary>
    [Serializable]
    public class ContosoServiceClientException : Exception
    {
        /// <inheritdoc/>
        public ContosoServiceClientException()
        {
        }

        /// <inheritdoc/>
        public ContosoServiceClientException(string message) : base(message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (message.Length == 0)
            {
                throw new ArgumentException("This exception type requires valid message value.", nameof(message));
            }
        }

        /// <inheritdoc/>
        public ContosoServiceClientException(string message, Exception innerException) : base(message, innerException)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (innerException == null)
            {
                throw new ArgumentNullException(nameof(innerException));
            }
            if (message.Length == 0)
            {
                throw new ArgumentException("This exception type requires valid message value.", nameof(message));
            }
        }

        /// <inheritdoc/>
        protected ContosoServiceClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _ = info ?? throw new ArgumentNullException(nameof(info));
        }
    }
}