using Project.Template.ServiceClient.Gateways;
using Project.Template.ServiceContracts;

using System;
using System.Net.Http;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The Template service client.
    /// </summary>
    public class TemplateServiceClient : ITemplateServiceClient
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateServiceClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClientFactory implementation to use</param>
        public TemplateServiceClient(IHttpClientFactory httpClientFactory)
        {
            Administration = new AdministrationGateway(httpClientFactory);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            (Administration as IDisposable)?.Dispose();
        }
    }
}
