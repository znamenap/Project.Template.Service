using Acme.Contoso.ServiceClient.Gateways;
using Acme.Contoso.ServiceContracts;

using System;
using System.Net.Http;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The Contoso service client.
    /// </summary>
    public class ContosoServiceClient : IContosoServiceClient
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContosoServiceClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClientFactory implementation to use</param>
        public ContosoServiceClient(IHttpClientFactory httpClientFactory)
        {
            Administration = new AdministrationGateway(httpClientFactory, nameof(ContosoServiceClient));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            (Administration as IDisposable)?.Dispose();
        }
    }
}
