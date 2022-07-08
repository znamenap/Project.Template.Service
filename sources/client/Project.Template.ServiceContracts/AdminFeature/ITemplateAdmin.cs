namespace Project.Template.ServiceContracts.AdminFeature
{
    /// <summary>
    /// The Template domain service administration.
    /// </summary>
    public interface ITemplateAdmin
    {
        /// <summary>
        /// Gets the application version.
        /// </summary>
        /// <returns>An ApplicationVersionDto.</returns>
        ApplicationVersionDto GetApplicationVersion();

        /// <summary>
        /// Requests the ping response from the Template domain service.
        /// </summary>
        PongDto Ping();
    }
}
