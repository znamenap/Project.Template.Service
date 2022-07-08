namespace Project.Template.ServiceContracts.Administration
{
    /// <summary>
    /// Represents the application version DTO.
    /// </summary>
    public class ApplicationVersionDto
    {
        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets the trademark.
        /// </summary>
        public string Trademark { get; set; }

        /// <summary>
        /// Gets the application title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the configuration name.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion { get; set; }

        /// <summary>
        /// Gets the file version.
        /// </summary>
        public string FileVersion { get; set; }

        /// <summary>
        /// Gets the informational version.
        /// </summary>
        public string InformationalVersion { get; set; }
    }
}