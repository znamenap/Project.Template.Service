using System.Runtime.Serialization;

namespace Acme.Contoso.ServiceContracts.Administration
{
    /// <summary>
    /// Represents the application version DTO.
    /// </summary>
    [DataContract(Name = nameof(ApplicationVersionDto), Namespace = ContosoConstants.DataContractNamespace)]
    public class ApplicationVersionDto
    {
        /// <summary>
        /// Gets the company name.
        /// </summary>
        [DataMember]
        public string Company { get; set; }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        [DataMember]
        public string Product { get; set; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        [DataMember]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets the trademark.
        /// </summary>
        [DataMember]
        public string Trademark { get; set; }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets the configuration name.
        /// </summary>
        [DataMember]
        public string Configuration { get; set; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        [DataMember]
        public string AssemblyVersion { get; set; }

        /// <summary>
        /// Gets the file version.
        /// </summary>
        [DataMember]
        public string FileVersion { get; set; }

        /// <summary>
        /// Gets the informational version.
        /// </summary>
        [DataMember]
        public string InformationalVersion { get; set; }
    }
}