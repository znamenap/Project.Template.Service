
using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ProjectAcronym.DomainName.ServiceContracts.Administration;

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectAcronym.DomainName.Services.Administration
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
            private readonly IHostEnvironment hostEnvironment;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            public Handler(ILogger<Ping> logger, IMapper mapper, IHostEnvironment hostEnvironment)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                this.hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            public Task<PongDto> Handle(Query request, CancellationToken cancellationToken)
            {
                const int kiloByte = 1024;
                const int megaByte = kiloByte * kiloByte;
                const string upTimeFormat = "{0:dd} days {0:hh} hrs {0:mm} mins {0:ss} secs";

                logger.LogInformation("Processing ping request.");
                var process = Process.GetCurrentProcess();
                var result = new PongDto {
                    ApplicationName = hostEnvironment.ApplicationName,
                    EnvironmentName = hostEnvironment.EnvironmentName,
                    ContenRootPath = hostEnvironment.ContentRootPath,
                    MachineUtcDateTime = DateTime.UtcNow,
                    ProcessId = Environment.ProcessId,
                    ProcessPath = Environment.ProcessPath,
                    ProcessUpTime = string.Format(upTimeFormat, DateTime.Now - process.StartTime),
                    TotalProcessorTime = string.Format(upTimeFormat, process.TotalProcessorTime),
                    UserProcessorTime = string.Format(upTimeFormat, process.UserProcessorTime),
                    Is64BitProcess = Environment.Is64BitProcess,
                    WorkingSetMB = Environment.WorkingSet / megaByte,
                    CurrentDirectory = Environment.CurrentDirectory,
                    UserName = Environment.UserName,
                    UserDomainName = Environment.UserDomainName,
                    MachineName = Environment.MachineName,
                    OSVersion = Environment.OSVersion.Adapt<OperatingSystemDto>(mapper.Config),
                    Is64BitOperatingSystem = Environment.Is64BitOperatingSystem,
                    SystemPageSizeKB = Environment.SystemPageSize / kiloByte,
                    ProcessorCount = Environment.ProcessorCount,
                    TickCount64 = Environment.TickCount64,
                    SystemUpTime = string.Format(upTimeFormat, TimeSpan.FromSeconds(Environment.TickCount64 / 1000)),
                    RuntimeVersion = Environment.Version.ToString(),
                };

                return Task.FromResult(result);
            }
        }
    }
}
