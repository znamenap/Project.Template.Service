using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

using System;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The service to validate Contoso service client options.
    /// </summary>
    public class ValidateContosoServiceClientOptions : IValidateOptions<ContosoServiceClientOptions>
    {
        private readonly ILogger<ValidateContosoServiceClientOptions> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateContosoServiceClientOptions"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ValidateContosoServiceClientOptions(ILogger<ValidateContosoServiceClientOptions> logger = null)
        {
            this.logger = logger ?? NullLogger<ValidateContosoServiceClientOptions>.Instance;
        }

        /// <inheritdoc />
        public ValidateOptionsResult Validate(string name, ContosoServiceClientOptions options)
        {
            try
            {
                logger.LogInformation($"Validating ServiceUri value: {options.ServiceUri}");
                new Uri(options.ServiceUri);
            }
            catch (Exception e)
            {
                var failureMessage = $"Provided ServiceUri='{options.ServiceUri}' of '{nameof(ContosoServiceClientOptions)}' is not valid URI value: {e.Message}";
                logger.LogError(failureMessage);
                return ValidateOptionsResult.Fail(failureMessage);
            }

            return ValidateOptionsResult.Success;
        }
    }
}