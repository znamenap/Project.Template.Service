﻿using Project.Template.ServiceContracts;

namespace Project.Template.ServiceClient
{
    /// <summary>
    /// The Template service client.
    /// </summary>
    public class TemplateServiceClient : ITemplateServiceClient
    {
        /// <summary>
        /// Gets the administration.
        /// </summary>
        public IAdmininistrationContract Administration { get; }
    }
}
