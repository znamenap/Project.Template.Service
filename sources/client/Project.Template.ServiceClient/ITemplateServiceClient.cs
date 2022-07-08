using Project.Template.ServiceContracts;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The template service client.
    /// </summary>
    public interface ITemplateServiceClient
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }
    }
}