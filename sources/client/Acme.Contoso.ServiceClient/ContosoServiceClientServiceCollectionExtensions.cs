using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using System;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The Contoso service client service collection extensions.
    /// </summary>
    public static class ContosoServiceClientServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the Contoso service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddContosoServiceClient(options =>
        ///  {
        ///      options.ServiceUri = "https://localhost:40443/";
        ///      options.TimeoutSeconds = 5;
        ///  });
        ///  </code>
        /// </example>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The explicit <see cref="ContosoServiceClientOptions"/>.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddContosoServiceClient(this IServiceCollection services, Action<ContosoServiceClientOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(paramName: nameof(options));

            services.Configure(options);

            return AddContosoServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the Contoso service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddContosoServiceClient();
        ///  
        ///  // Expecting you to have following section in appsettings.json:
        ///    "ContosoServiceClient": {
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
        public static IServiceCollection AddContosoServiceClient(this IServiceCollection services, string sectionName = null)
        {
            services.AddOptions<ContosoServiceClientOptions>()
                .BindConfiguration(sectionName ?? ContosoServiceClientOptions.Name,
                    binderOptions => binderOptions.ErrorOnUnknownConfiguration = true)
                .ValidateDataAnnotations();

            return AddContosoServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the Contoso service client common implementation.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An IServiceCollection.</returns>
        private static IServiceCollection AddContosoServiceClientImplementation(IServiceCollection services)
        {
            services.AddScoped<IContosoServiceClient, ContosoServiceClient>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<ContosoServiceClientOptions>, ValidateContosoServiceClientOptions>());
            services.AddHttpClient<ContosoServiceClient>(nameof(ContosoServiceClient))
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var optionsProvider = serviceProvider.GetRequiredService<IOptionsMonitor<ContosoServiceClientOptions>>();
                    var options = optionsProvider.CurrentValue;
                    httpClient.BaseAddress = new Uri(options.ServiceUri);
                    httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
                });

            return services;
        }
    }
}
