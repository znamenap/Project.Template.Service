using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Project.Template.Services
{
    /// <summary>
    /// The services collection extensions.
    /// </summary>
    public static class ServicesCollectionExtensions
    {
        /// <summary>
        /// Adds the template services and controllers.
        /// </summary>
        public static IServiceCollection AddTemplateServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServicesCollectionExtensions).Assembly);

            return services;
        }
    }
}
