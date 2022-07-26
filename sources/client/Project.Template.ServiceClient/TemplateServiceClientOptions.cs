using System.ComponentModel.DataAnnotations;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The template service client options.
    /// </summary>
    public class TemplateServiceClientOptions
    {
        /// <summary>
        /// The name of the options section for these options.
        /// </summary>
        public readonly static string Name = "TemplateServiceClient";

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateServiceClientOptions"/> class.
        /// </summary>
        public TemplateServiceClientOptions()
        {
            TimeoutSeconds = 140;
        }

        /// <summary>
        /// Gets or sets the service URI.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "requires not null and valid URI string value")]
        public string ServiceUri { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        public uint TimeoutSeconds { get; set; }
    }
}