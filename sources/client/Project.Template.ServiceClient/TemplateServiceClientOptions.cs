using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The template service client options.
    /// </summary>
    public class TemplateServiceClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateServiceClientOptions"/> class.
        /// </summary>
        public TemplateServiceClientOptions()
        {
            Timeout = TimeSpan.FromSeconds(140);
        }

        /// <summary>
        /// Gets or sets the service URI.
        /// </summary>
        [Required]
        public Uri ServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        public TimeSpan Timeout { get; set; }
    }
}