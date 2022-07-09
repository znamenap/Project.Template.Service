
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

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            public Handler(ILogger<Ping> logger)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            public Task<PongDto> Handle(Query request, CancellationToken cancellationToken)
            {
                logger.LogInformation("Processing ping request.");
                var result = new PongDto {
                    MachineUtcDateTime = DateTime.UtcNow,
                    ProcessId = Environment.ProcessId,
                    ProcessPath = Environment.ProcessPath,
                    Is64BitProcess = Environment.Is64BitProcess,
                    CurrentDirectory = Environment.CurrentDirectory,
                    UserName = Environment.UserName,
                    UserDomainName = Environment.UserDomainName,
                    MachineName = Environment.MachineName,
                    OSVersion = Environment.OSVersion,
                    Is64BitOperatingSystem = Environment.Is64BitOperatingSystem,
                    SystemPageSizeKB = Environment.SystemPageSize / 1024,
                    WorkingSetMB = Environment.WorkingSet / 1024 / 1024,
                    ProcessorCount = Environment.ProcessorCount,
                    TickCount64 = Environment.TickCount64,
                    UpTime = string.Format("{0:dd} days {0:hh} hrs {0:mm} mins {0:ss} secs", TimeSpan.FromSeconds(Environment.TickCount64 / 1000)),
                    RuntimeVersion = Environment.Version.ToString(),
                };
                return Task.FromResult(result);
            }
        }
    }
}
