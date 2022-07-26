using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using System;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The template service client service collection extensions.
    /// </summary>
    public static class TemplateServiceClientServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the template service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddTemplateServiceClient(options =>
        ///  {
        ///      options.ServiceUri = "https://localhost:40443/";
        ///      options.TimeoutSeconds = 5;
        ///  });
        ///  </code>
        /// </example>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The explicit <see cref="TemplateServiceClientOptions"/>.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddTemplateServiceClient(this IServiceCollection services, Action<TemplateServiceClientOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(paramName: nameof(options));

            services.Configure(options);

            return AddTemplateServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the template service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddTemplateServiceClient();
        ///  
        ///  // Expecting you to have following section in appsettings.json:
        ///    "TemplateServiceClient": {
        ///      "ServiceUri": "https://localhost:40443/",
        ///      "TimeoutSeconds": 10
        ///    }
        /// </code>
        /// </example>
        /// <remarks>
        /// There is still an option to pass the <paramref name="sectionName"/> to influence the process
        /// of binding to the configuration section.
        /// </remarks>
        /// <param name="services">The service collection.</param>
        /// <param name="sectionName">The name of the section to bind the options from.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddTemplateServiceClient(this IServiceCollection services, string sectionName = null)
        {
            services.AddOptions<TemplateServiceClientOptions>()
                .BindConfiguration(sectionName ?? TemplateServiceClientOptions.Name,
                    binderOptions => binderOptions.ErrorOnUnknownConfiguration = true)
                .ValidateDataAnnotations();

            return AddTemplateServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the template service client common implementation.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An IServiceCollection.</returns>
        private static IServiceCollection AddTemplateServiceClientImplementation(IServiceCollection services)
        {
            services.AddScoped<ITemplateServiceClient, TemplateServiceClient>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<TemplateServiceClientOptions>, ValidateTemplateServiceClientOptions>());
            services.AddHttpClient<TemplateServiceClient>(nameof(TemplateServiceClient))
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var optionsProvider = serviceProvider.GetRequiredService<IOptionsMonitor<TemplateServiceClientOptions>>();
                    var options = optionsProvider.CurrentValue;
                    httpClient.BaseAddress = new Uri(options.ServiceUri);
                    httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
                });

            return services;
        }
    }
}
