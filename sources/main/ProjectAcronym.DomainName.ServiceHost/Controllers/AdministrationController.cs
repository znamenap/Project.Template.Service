
using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using ProjectAcronym.DomainName.ServiceContracts;
using ProjectAcronym.DomainName.ServiceContracts.Administration;
using ProjectAcronym.DomainName.Services.Administration;

using System;
using System.Threading.Tasks;

namespace ProjectAcronym.DomainName.ServiceHost.Controllers
{
    /// <summary>
    /// The services administration controller.
    /// </summary>
    [ApiController]
    [Route("admin")]
    public class AdministrationController : ControllerBase, IAdmininistrationContract
    {
        private readonly IMediator mediatr;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationController"/> class.
        /// </summary>
        public AdministrationController(IMediator mediatr)
        {
            this.mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
        }

        /// <inheritdoc />
        [HttpGet("version")]
        public Task<ApplicationVersionDto> Version()
        {
            return mediatr.Send(new AppVersion.Query());
        }

        /// <inheritdoc />
        [HttpGet("ping")]
        public Task<PongDto> Ping()
        {
            return mediatr.Send(new Ping.Query());
        }

        /// <inheritdoc />
        [HttpGet("routes")]
        public Task<RoutesDto> Routes()
        {
            return mediatr.Send(new Routes.Query());
        }

        /// <inheritdoc />
        [HttpPost("reconfigure")]
        public Task Reconfigure()
        {
            return mediatr.Send(new Reconfigure.Command());
        }
    }
}