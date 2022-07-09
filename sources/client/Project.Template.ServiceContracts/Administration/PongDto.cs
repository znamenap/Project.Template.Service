using System;

namespace Project.Template.ServiceContracts.Administration
{
    /// <summary>
    /// The response to the ping request.
    /// </summary>
    public class PongDto
    {
        /// <summary>
        /// The actual machine date time in UTC timezone.
        /// </summary>
        public DateTime MachineUtcDateTime { get; set; }

        /// <summary>
        /// The process id of the service.
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// The path to the process's image.
        /// </summary>
        public string ProcessPath { get; set; }

        /// <summary>
        /// Indicator if this is 64 bit process.
        /// </summary>
        public bool Is64BitProcess { get; set; }

        /// <summary>
        /// Current working directory of the process.
        /// </summary>
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// Actual username of the process running the service.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Actual username's domain of the process running the service.
        /// </summary>
        public string UserDomainName { get; set; }

        /// <summary>
        /// The machine name hosting this service.
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// The operating system details.
        /// </summary>
        public OperatingSystem OSVersion { get; set; }

        /// <summary>
        /// Indicator if the operating system is 64 bit.
        /// </summary>
        public bool Is64BitOperatingSystem { get; set; }

        /// <summary>
        /// The actual number of kilo bytes in the operating system's memory page.
        /// </summary>
        public int SystemPageSizeKB { get; set; }

        /// <summary>
        /// The actual number of mega bytes of the physical memory mapped to the process context.
        /// </summary>
        public long WorkingSetMB { get; set; }

        /// <summary>
        /// The count of the processors available to the current service.
        /// </summary>
        public int ProcessorCount { get; set; }

        /// <summary>
        /// Number of milliseconds since the system started.
        /// </summary>
        public long TickCount64 { get; set; }

        /// <summary>
        /// System's Up Time.
        /// </summary>
        public string UpTime { get; set; }

        /// <summary>
        /// .NET Runtime Version
        /// </summary>
        public string RuntimeVersion { get; set; }
    }
}