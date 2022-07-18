﻿using Refit;

using System;
using System.Threading.Tasks;

namespace Project.Template.ServiceClient.Gateways
{
    /// <summary>
    /// The abstract gateway base.
    /// </summary>
    internal class AbstractGatewayBase
    {
        /// <summary>
        /// Initiates the gateway call and processes the response. It checks the status code and throws 
        /// <see cref="TemplateServiceClientException"/> exception if the call failed.
        /// </summary>
        /// <param name="operationName">The operation name.</param>
        /// <param name="gatewayCall">The gateway call.</param>
        /// <returns>The response's content.</returns>
        protected async Task<TContent> ProcessResponse<TContent>(string operationName, Func<Task<IApiResponse<TContent>>> gatewayCall)
        {
            using var response = await gatewayCall();
            if (!response.IsSuccessStatusCode)
            {
                throw new TemplateServiceClientException(
                    $"Error while processing remote request of {operationName} resulted with status code {response.StatusCode}.", response.Error);
            }

            return response.Content;
        }
    }
}