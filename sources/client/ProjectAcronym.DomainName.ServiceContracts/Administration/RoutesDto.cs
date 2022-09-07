using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProjectAcronym.DomainName.ServiceContracts.Administration
{
    /// <summary>
    /// Represents a collection of routes to this service.
    /// </summary>
    [DataContract(Namespace = DomainNameConstants.DataContractNamespace)]
    public class RoutesDto
    {
        /// <summary>
        /// The list of the routes.
        /// </summary>
        [DataMember]
        public List<RouteDto> Routes { get; set; }
    }
}
