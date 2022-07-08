﻿using Mapster;

using MapsterMapper;

using MediatR;

using Microsoft.Extensions.Logging;

using Project.Template.Domain.Administration;
using Project.Template.ServiceContracts.Administration;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Template.Services.Administration
{
    /// <summary>
    /// The version.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// The query for Application Version.
        /// </summary>
        public class Query : IRequest<ApplicationVersionDto>
        {
        }

        /// <summary>
        /// The Application Version Request handler.
        /// </summary>
        public class Handler : IRequestHandler<Query, ApplicationVersionDto>
        {
            private readonly ILogger<Version> logger;
            private readonly IMapper mapper;

            /// <summary>
            /// Initializes a new instance of the <see cref="Handler"/> class.
            /// </summary>
            public Handler(ILogger<Version> logger, IMapper mapper)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
                this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            /// <summary>
            /// Handles the request for the application version.
            /// </summary>
            public Task<ApplicationVersionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                logger.LogInformation("Processing application version request.");
                var applicationVersion = ApplicationVersion.Create();
                return Task.FromResult(applicationVersion.Adapt<ApplicationVersionDto>(mapper.Config));
            }
        }
    }
}
