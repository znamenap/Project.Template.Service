
using MediatR;

using Microsoft.AspNetCore.Mvc;

using Project.Template.ServiceContracts;
using Project.Template.ServiceContracts.Administration;
using Project.Template.Services.Administration;

using System;
using System.Threading.Tasks;

namespace Project.Template.ServiceHost.Controllers
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

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <returns>An ApplicationVersionDto.</returns>
        [HttpGet("version")]
        public Task<ApplicationVersionDto> GetApplicationVersion()
        {
            return mediatr.Send(new AppVersion.Query());
        }

        /// <summary>
        /// Requests the ping response from the Template domain service.
        /// </summary>
        [HttpGet("ping")]
        public Task<PongDto> Ping()
        {
            return mediatr.Send(new Ping.Query());
        }
    }
}