using System.ComponentModel.DataAnnotations;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The Contoso service client options.
    /// </summary>
    public class ContosoServiceClientOptions
    {
        /// <summary>
        /// The name of the options section for these options.
        /// </summary>
        public readonly static string Name = "ContosoServiceClient";

        /// <summary>
        /// Initializes a new instance of the <see cref="ContosoServiceClientOptions"/> class.
        /// </summary>
        public ContosoServiceClientOptions()
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