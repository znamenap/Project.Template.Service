using ProjectAcronym.DomainName.ServiceContracts;

using System;

namespace ProjectAcronym.DomainName.ServiceClient
{
    /// <summary>
    /// The DomainName service client.
    /// </summary>
    public interface IDomainNameServiceClient : IDisposable
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }
    }
}