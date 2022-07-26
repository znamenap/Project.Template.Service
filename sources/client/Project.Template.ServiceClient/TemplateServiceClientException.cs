using System;
using System.Runtime.Serialization;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The Template service client exception.
    /// </summary>
    [Serializable]
    public class TemplateServiceClientException : Exception
    {
        /// <inheritdoc/>
        public TemplateServiceClientException()
        {
        }

        /// <inheritdoc/>
        public TemplateServiceClientException(string message) : base(message)
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
        public TemplateServiceClientException(string message, Exception innerException) : base(message, innerException)
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
        protected TemplateServiceClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            _ = info ?? throw new ArgumentNullException(nameof(info));
        }
    }
}