using MapsterMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Project.Template.ServiceContracts.Administration;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Template.Services.Administration
{
    /// <summary>
    /// The ping request and handler.
    /// </summary>
    public class Ping
    {
        /// <summary>
        /// The query for the Ping operation to respond with PongDto.
        /// </summary>
        public class Query : IRequest<PongDto>
        { }

        /// <summary>
        /// The handler for Ping request.
        /// </summary>
        public class Handler : IRequestHandler<Query, PongDto>
        {
            private readonly ILogger<Ping> logger;
            private readonly IMapper mapper;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            public Handler(ILogger<Ping> logger, IMapper mapper)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            public Task<PongDto> Handle(Query request, CancellationToken cancellationToken)
            {
                logger.LogInformation("Processing ping request.");
                return Task.FromResult(new PongDto());
            }
        }
    }
}
