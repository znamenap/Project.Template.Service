using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Acme.Contoso.ServiceContracts.Administration
{
    /// <summary>
    /// Represents a collection of routes to this service.
    /// </summary>
    [DataContract(Namespace = ContosoConstants.DataContractNamespace)]
    public class RoutesDto
    {
        /// <summary>
        /// The list of the routes.
        /// </summary>
        [DataMember]
        public List<RouteDto> Routes { get; set; }
    }
}
