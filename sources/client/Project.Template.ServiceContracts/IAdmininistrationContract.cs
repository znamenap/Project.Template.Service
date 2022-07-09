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
        Task<ApplicationVersionDto> GetApplicationVersion();

        /// <summary>
        /// Requests the ping response from the Template domain service.
        /// </summary>
        Task<PongDto> Ping();
    }
}
