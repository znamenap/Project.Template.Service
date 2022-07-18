using Project.Template.ServiceContracts;
using Project.Template.ServiceContracts.Administration;

using Refit;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.Template.ServiceClient.Gateways
{
    /// <summary>
    /// The gateway to administration contract at the remote service.
    /// </summary>
    internal class AdministrationGateway : AbstractGatewayBase, IAdmininistrationContract, IDisposable
    {
        private readonly IAdministrationContractDescriptor gateway;
        private readonly HttpClient client;

        /// <summary>
        /// The administration contract descriptor.
        /// </summary>
        internal interface IAdministrationContractDescriptor
        {
            /// <inheritdoc />
            [Get("/version")]
            Task<IApiResponse<ApplicationVersionDto>> Version();

            /// <inheritdoc />
            [Get("/ping")]
            Task<IApiResponse<PongDto>> Ping();

            /// <inheritdoc />
            [Get("/routes")]
            Task<IApiResponse<RoutesDto>> Routes();

            /// <inheritdoc />
            [Post("/reconfigure")]
            Task<IApiResponse<object>> Reconfigure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationGateway"/> class.
        /// </summary>
        public AdministrationGateway(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(client.BaseAddress, "admin");
            gateway = RestService.For<IAdministrationContractDescriptor>(client);
        }

        /// <inheritdoc />
        public Task<ApplicationVersionDto> Version()
        {
            return ProcessResponse(nameof(Version), () => gateway.Version());
        }

        /// <inheritdoc />
        public Task<PongDto> Ping()
        {
            return ProcessResponse(nameof(Ping), () => gateway.Ping());
        }

        /// <inheritdoc />
        public Task<RoutesDto> Routes()
        {
            return ProcessResponse(nameof(Routes), () => gateway.Routes());
        }

        /// <inheritdoc />
        public Task Reconfigure()
        {
            return ProcessResponse(nameof(Reconfigure), () => gateway.Reconfigure());
        }

        /// <inheritdoc />
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
