using Project.Template.ServiceContracts;

using System;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The template service client.
    /// </summary>
    public interface ITemplateServiceClient : IDisposable
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }
    }
}