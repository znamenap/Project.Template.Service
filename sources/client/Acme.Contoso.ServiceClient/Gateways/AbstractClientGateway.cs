using Refit;

using System;
using System.Threading.Tasks;

namespace Acme.Contoso.ServiceClient.Gateways
{
    /// <summary>
    /// The abstract gateway client.
    /// </summary>
    internal class AbstractClientGateway
    {
        /// <summary>
        /// Initiates the gateway call and processes the response. It checks the status code and throws 
        /// <see cref="ContosoServiceClientException"/> exception if the call failed.
        /// </summary>
        /// <param name="operationName">The operation name.</param>
        /// <param name="gatewayCall">The gateway call.</param>
        /// <returns>The response's content.</returns>
        protected async Task<TContent> ProcessResponse<TContent>(string operationName, Func<Task<IApiResponse<TContent>>> gatewayCall)
        {
            using var response = await gatewayCall();
            if (!response.IsSuccessStatusCode)
            {
                throw new ContosoServiceClientException(
                    $"Error while processing remote request of {operationName} resulted with status code {response.StatusCode}.", response.Error);
            }

            return response.Content;
        }
    }
}