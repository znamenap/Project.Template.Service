using Acme.Contoso.ServiceContracts;

using System;

namespace Acme.Contoso.ServiceClient
{
    /// <summary>
    /// The Contoso service client.
    /// </summary>
    public interface IContosoServiceClient : IDisposable
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }
    }
}