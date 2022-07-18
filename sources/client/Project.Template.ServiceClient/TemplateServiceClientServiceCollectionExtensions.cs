using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="services">The service collection.</param>
        /// <param name="options"></param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddTemplateServiceClient(this IServiceCollection services, Action<TemplateServiceClientOptions> options = null)
        {
            if (options != null)
            {
                services.Configure(options);
            }
            services.AddScoped<ITemplateServiceClient, TemplateServiceClient>();
            services.AddOptions<IOptions<TemplateServiceClientOptions>>(nameof(TemplateServiceClient));
            services.AddHttpClient<TemplateServiceClient>((provider, httpClient) =>
            {
                var options = provider
                    .GetRequiredService<IOptions<TemplateServiceClientOptions>>()
                    .Value;
                httpClient.BaseAddress = options.ServiceUri;
                httpClient.Timeout = options.Timeout;
            });

            return services;
        }
    }
}
