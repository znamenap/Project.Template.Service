using System;
using System.Runtime.Serialization;

namespace Acme.Contoso.ServiceContracts.Administration
{
    /// <summary>
    /// The response to the ping request.
    /// </summary>
    [DataContract(Name = nameof(PongDto), Namespace = ContosoConstants.DataContractNamespace)]
    public class PongDto
    {
        /// <summary>
        /// The application name of this service.
        /// </summary>
        [DataMember]
        public string ApplicationName { get; set; }

        /// <summary>
        /// THe environment name used for this application instance.
        /// </summary>
        [DataMember]
        public string EnvironmentName { get; set; }

        /// <summary>
        /// The content root path for this application.
        /// </summary>
        [DataMember]
        public string ContenRootPath { get; set; }

        /// <summary>
        /// The actual machine date time in UTC timezone.
        /// </summary>
        [DataMember]
        public DateTime MachineUtcDateTime { get; set; }

        /// <summary>
        /// The process id of the service.
        /// </summary>
        [DataMember]
        public int ProcessId { get; set; }

        /// <summary>
        /// The path to the process's image.
        /// </summary>
        [DataMember]
        public string ProcessPath { get; set; }

        /// <summary>
        /// Indicator if this is 64 bit process.
        /// </summary>
        [DataMember]
        public bool Is64BitProcess { get; set; }

        /// <summary>
        /// Process's up time
        /// </summary>
        [DataMember]
        public string ProcessUpTime { get; set; }

        /// <summary>
        /// Total processor time for this process.
        /// </summary>
        [DataMember]
        public string TotalProcessorTime { get; set; }

        /// <summary>
        /// User processor time for this process.
        /// </summary>
        [DataMember]
        public string UserProcessorTime { get; set; }

        /// <summary>
        /// Current working directory of the process.
        /// </summary>
        [DataMember]
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// Actual username of the process running the service.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Actual username's domain of the process running the service.
        /// </summary>
        [DataMember]
        public string UserDomainName { get; set; }

        /// <summary>
        /// The machine name hosting this service.
        /// </summary>
        [DataMember]
        public string MachineName { get; set; }

        /// <summary>
        /// The operating system details.
        /// </summary>
        [DataMember]
        public OperatingSystemDto OSVersion { get; set; }

        /// <summary>
        /// Indicator if the operating system is 64 bit.
        /// </summary>
        [DataMember]
        public bool Is64BitOperatingSystem { get; set; }

        /// <summary>
        /// The actual number of kilo bytes in the operating system's memory page.
        /// </summary>
        [DataMember]
        public int SystemPageSizeKB { get; set; }

        /// <summary>
        /// The actual number of mega bytes of the physical memory mapped to the process context.
        /// </summary>
        [DataMember]
        public long WorkingSetMB { get; set; }

        /// <summary>
        /// The count of the processors available to the current service.
        /// </summary>
        [DataMember]
        public int ProcessorCount { get; set; }

        /// <summary>
        /// Number of milliseconds since the system started.
        /// </summary>
        [DataMember]
        public long TickCount64 { get; set; }

        /// <summary>
        /// System's Up Time.
        /// </summary>
        [DataMember]
        public string SystemUpTime { get; set; }

        /// <summary>
        /// .NET Runtime Version
        /// </summary>
        [DataMember]
        public string RuntimeVersion { get; set; }
    }
}