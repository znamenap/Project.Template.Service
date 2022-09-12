
using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Acme.Contoso.Services.Administration
{
    /// <summary>
    /// The configuration commands and handlers.
    /// </summary>
    public class Reconfigure
    {
        /// <summary>
        /// The command to reload configuration.
        /// </summary>
        public class Command : IRequest<Unit>
        {
        }

        /// <summary>
        /// The handler of the Reload Configuration Command.
        /// </summary>
        public class Handler : IRequestHandler<Command>
        {
            private readonly IConfigurationRoot configurationRoot;
            private readonly ILogger<Reconfigure> logger;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            /// <param name="configuration">The configuration instance to use.</param>
            /// <param name="logger">The logger where to log the debug configuration view.</param>
            public Handler(IConfiguration configuration, ILogger<Reconfigure> logger)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
                configurationRoot = configuration as IConfigurationRoot ?? throw new ArgumentNullException(nameof(configuration));
            }

            /// <summary>
            /// Performs the reload operation on top of the provided instance of IConfigurationRoot.
            /// </summary>
            /// <param name="command">The request to handle.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>Just the unit.</returns>
            public Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                configurationRoot.Reload();
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    var debugView = configurationRoot.GetDebugView();
                    logger.LogDebug("Reconfiguration caused following view {debugView}", debugView);
                }
                return Unit.Task;
            }
        }
    }
}
