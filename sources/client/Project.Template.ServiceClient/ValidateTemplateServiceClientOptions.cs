using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

using System;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The service to validate template service client options.
    /// </summary>
    public class ValidateTemplateServiceClientOptions : IValidateOptions<TemplateServiceClientOptions>
    {
        private readonly ILogger<ValidateTemplateServiceClientOptions> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateTemplateServiceClientOptions"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ValidateTemplateServiceClientOptions(ILogger<ValidateTemplateServiceClientOptions> logger = null)
        {
            this.logger = logger ?? NullLogger<ValidateTemplateServiceClientOptions>.Instance;
        }

        /// <inheritdoc />
        public ValidateOptionsResult Validate(string name, TemplateServiceClientOptions options)
        {
            try
            {
                logger.LogInformation($"Validating ServiceUri value: {options.ServiceUri}");
                new Uri(options.ServiceUri);
            }
            catch (Exception e)
            {
                var failureMessage = $"Provided ServiceUri='{options.ServiceUri}' of '{nameof(TemplateServiceClientOptions)}' is not valid URI value: {e.Message}";
                logger.LogError(failureMessage);
                return ValidateOptionsResult.Fail(failureMessage);
            }

            return ValidateOptionsResult.Success;
        }
    }
}