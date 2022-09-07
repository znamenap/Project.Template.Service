using ProjectAcronym.DomainName.ServiceClient.Gateways;
using ProjectAcronym.DomainName.ServiceContracts;

using System;
using System.Net.Http;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The DomainName service client.
    /// </summary>
    public class DomainNameServiceClient : IDomainNameServiceClient
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNameServiceClient"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HttpClientFactory implementation to use</param>
        public DomainNameServiceClient(IHttpClientFactory httpClientFactory)
        {
            Administration = new AdministrationGateway(httpClientFactory, nameof(DomainNameServiceClient));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            (Administration as IDisposable)?.Dispose();
        }
    }
}
