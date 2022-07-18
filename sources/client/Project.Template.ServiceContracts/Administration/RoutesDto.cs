using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Project.Template.ServiceContracts.Administration
{
    /// <summary>
    /// Represents a collection of routes to this service.
    /// </summary>
    [DataContract(Namespace = TemplateConstants.DataContractNamespace)]
    public class RoutesDto
    {
        /// <summary>
        /// The list of the routes.
        /// </summary>
        [DataMember]
        public List<RouteDto> Routes { get; set; }
    }
}
