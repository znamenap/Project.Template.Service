using MediatR;

using Microsoft.AspNetCore.Routing;

using Project.Template.ServiceContracts.Administration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Template.Services.Administration
{
    /// <summary>
    /// The routes CQS.
    /// </summary>
    public static class Routes
    {
        /// <summary>
        /// The Routes query.
        /// </summary>
        public class Query : IRequest<RoutesDto>
        { }

        /// <summary>
        /// The Routes handler.
        /// </summary>
        public class Handler : IRequestHandler<Query, RoutesDto>
        {
            private readonly IList<EndpointDataSource> endpointDataSources;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="endpointDataSources">The endpoint data sources.</param>
            public Handler(IEnumerable<EndpointDataSource> endpointDataSources)
            {
                this.endpointDataSources = endpointDataSources?.ToList() ?? throw new ArgumentNullException(nameof(endpointDataSources));
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>Response from the request</returns>
            public Task<RoutesDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var routes = endpointDataSources
                    .SelectMany(x => x.Endpoints)
                    .OfType<RouteEndpoint>()
                    .Select(x => new RouteDto {
                        DisplayName = x.DisplayName,
                        Method = string.Join(",", x.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods),
                        Path = x.RoutePattern.RawText,
                        Parameters = x.RoutePattern.Parameters
                            .Select(x => $"[Name={x.Name}; Kind={x.ParameterKind}; IsParameter={x.IsParameter}; PartKind={x.PartKind}; IsSeparator={x.Default}; Default={x.Default}")
                            .ToList()
                    })
                    .ToList();

                var routesDto = new RoutesDto {
                    Routes = new List<RouteDto>(routes)
                };

                return Task.FromResult(routesDto);
            }
        }
    }
}
