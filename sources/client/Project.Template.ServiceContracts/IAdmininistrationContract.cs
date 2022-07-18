using Project.Template.ServiceContracts.Administration;

using System.Threading.Tasks;

namespace Project.Template.ServiceContracts
{
    /// <summary>
    /// The Template domain service administration.
    /// </summary>
    public interface IAdmininistrationContract
    {
        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <returns>An ApplicationVersionDto.</returns>
        Task<ApplicationVersionDto> Version();

        /// <summary>
        /// Requests the ping response from the Template domain service.
        /// </summary>
        Task<PongDto> Ping();

        /// <summary>
        /// Returns the routes of this service endpoint.
        /// </summary>
        /// <returns>The routes.</returns>
        public Task<RoutesDto> Routes();

        /// <summary>
        /// Reloads the configuration of this service.
        /// </summary>
        public Task Reconfigure();
    }
}
