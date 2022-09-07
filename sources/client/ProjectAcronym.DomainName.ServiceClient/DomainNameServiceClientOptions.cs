using System.ComponentModel.DataAnnotations;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The DomainName service client options.
    /// </summary>
    public class DomainNameServiceClientOptions
    {
        /// <summary>
        /// The name of the options section for these options.
        /// </summary>
        public readonly static string Name = "DomainNameServiceClient";

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNameServiceClientOptions"/> class.
        /// </summary>
        public DomainNameServiceClientOptions()
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