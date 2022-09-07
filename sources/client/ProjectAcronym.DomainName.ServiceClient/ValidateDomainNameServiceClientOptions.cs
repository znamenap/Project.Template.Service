using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

using System;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The service to validate DomainName service client options.
    /// </summary>
    public class ValidateDomainNameServiceClientOptions : IValidateOptions<DomainNameServiceClientOptions>
    {
        private readonly ILogger<ValidateDomainNameServiceClientOptions> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateDomainNameServiceClientOptions"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ValidateDomainNameServiceClientOptions(ILogger<ValidateDomainNameServiceClientOptions> logger = null)
        {
            this.logger = logger ?? NullLogger<ValidateDomainNameServiceClientOptions>.Instance;
        }

        /// <inheritdoc />
        public ValidateOptionsResult Validate(string name, DomainNameServiceClientOptions options)
        {
            try
            {
                logger.LogInformation($"Validating ServiceUri value: {options.ServiceUri}");
                new Uri(options.ServiceUri);
            }
            catch (Exception e)
            {
                var failureMessage = $"Provided ServiceUri='{options.ServiceUri}' of '{nameof(DomainNameServiceClientOptions)}' is not valid URI value: {e.Message}";
                logger.LogError(failureMessage);
                return ValidateOptionsResult.Fail(failureMessage);
            }

            return ValidateOptionsResult.Success;
        }
    }
}