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
        }

        /// <inheritdoc/>
        public TemplateServiceClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc/>
        protected TemplateServiceClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}