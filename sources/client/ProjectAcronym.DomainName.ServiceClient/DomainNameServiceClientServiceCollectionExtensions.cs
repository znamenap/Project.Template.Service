using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using System;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The DomainName service client service collection extensions.
    /// </summary>
    public static class DomainNameServiceClientServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the DomainName service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddDomainNameServiceClient(options =>
        ///  {
        ///      options.ServiceUri = "https://localhost:40443/";
        ///      options.TimeoutSeconds = 5;
        ///  });
        ///  </code>
        /// </example>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The explicit <see cref="DomainNameServiceClientOptions"/>.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddDomainNameServiceClient(this IServiceCollection services, Action<DomainNameServiceClientOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(paramName: nameof(options));

            services.Configure(options);

            return AddDomainNameServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the DomainName service client.
        /// </summary>
        /// <example>
        /// <code>
        ///  builder.Services.AddDomainNameServiceClient();
        ///  
        ///  // Expecting you to have following section in appsettings.json:
        ///    "DomainNameServiceClient": {
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
        public static IServiceCollection AddDomainNameServiceClient(this IServiceCollection services, string sectionName = null)
        {
            services.AddOptions<DomainNameServiceClientOptions>()
                .BindConfiguration(sectionName ?? DomainNameServiceClientOptions.Name,
                    binderOptions => binderOptions.ErrorOnUnknownConfiguration = true)
                .ValidateDataAnnotations();

            return AddDomainNameServiceClientImplementation(services);
        }

        /// <summary>
        /// Adds the DomainName service client common implementation.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>An IServiceCollection.</returns>
        private static IServiceCollection AddDomainNameServiceClientImplementation(IServiceCollection services)
        {
            services.AddScoped<IDomainNameServiceClient, DomainNameServiceClient>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<DomainNameServiceClientOptions>, ValidateDomainNameServiceClientOptions>());
            services.AddHttpClient<DomainNameServiceClient>(nameof(DomainNameServiceClient))
                .ConfigureHttpClient((serviceProvider, httpClient) =>
                {
                    var optionsProvider = serviceProvider.GetRequiredService<IOptionsMonitor<DomainNameServiceClientOptions>>();
                    var options = optionsProvider.CurrentValue;
                    httpClient.BaseAddress = new Uri(options.ServiceUri);
                    httpClient.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
                });

            return services;
        }
    }
}
