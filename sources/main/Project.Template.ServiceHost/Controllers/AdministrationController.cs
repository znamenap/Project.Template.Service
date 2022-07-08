using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Project.Template.Domain.Administration;
using Project.Template.ServiceContracts;
using Project.Template.ServiceContracts.Administration;

namespace Project.Template.ServiceHost.Controllers
{
    /// <summary>
    /// The admin controller.
    /// </summary>
    [ApiController]
    [Route("admin")]
    public class AdministrationController : ControllerBase, IAdmininistrationContract
    {
        private readonly ILogger<AdministrationController> logger;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrationController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        public AdministrationController(ILogger<AdministrationController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <returns>An ApplicationVersionDto.</returns>
        [HttpGet("version")]
        public ApplicationVersionDto GetApplicationVersion()
        {
            logger.LogInformation("Processing application version request.");
            var applicationVersion = ApplicationVersion.Create();
            return applicationVersion.Adapt<ApplicationVersionDto>(mapper.Config);
        }

        /// <summary>
        /// Requests the ping response from the Template domain service.
        /// </summary>
        [HttpGet("ping")]
        public PongDto Ping()
        {
            logger.LogInformation("Processing ping request.");
            return new PongDto();
        }
    }
}