using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Project.Template.ServiceContracts.Administration
{
    /// <summary>
    /// Represents a route to this service.
    /// </summary>
    [DataContract(Namespace = TemplateConstants.DataContractNamespace)]
    public class RouteDto
    {
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        [DataMember]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [DataMember]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        [DataMember]
        public List<string> Parameters { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Method} : {Path} : {DisplayName}";
        }
    }
}