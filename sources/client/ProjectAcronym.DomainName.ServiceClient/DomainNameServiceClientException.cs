using System;
using System.Runtime.Serialization;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The DomainName service client exception.
    /// </summary>
    [Serializable]
    public class DomainNameServiceClientException : Exception
    {
        /// <inheritdoc/>
        public DomainNameServiceClientException()
        {
        }

        /// <inheritdoc/>
        public DomainNameServiceClientException(string message) : base(message)
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
        public DomainNameServiceClientException(string message, Exception innerException) : base(message, innerException)
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
        protected DomainNameServiceClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _ = info ?? throw new ArgumentNullException(nameof(info));
        }
    }
}