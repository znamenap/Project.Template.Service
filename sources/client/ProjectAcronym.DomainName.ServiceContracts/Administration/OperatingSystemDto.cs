using System.Runtime.Serialization;

namespace ProjectAcronym.DomainName.ServiceContracts.Administration
{
    /// <summary>
    /// The operating system.
    /// </summary>
    [DataContract(Name = nameof(PongDto), Namespace = DomainNameConstants.DataContractNamespace)]
    public class OperatingSystemDto
    {
        /// <summary>
        /// The platform of the operating system.
        /// </summary>
        [DataMember]
        public int Platform { get; set; }

        /// <summary>
        /// The service pack.
        /// </summary>
        [DataMember]
        public string ServicePack { get; set; }

        /// <summary>
        /// The version.
        /// </summary>
        [DataMember]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version string.
        /// </summary>
        [DataMember]
        public string VersionString { get; set; }
    }
}