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

            return services;
        }

        /// <summary>
        /// Adds the template controllers.
        /// </summary>
        public static IMvcBuilder AddTemplateControllers(this IMvcBuilder mvcBuilder)
        {
            // Register all controllers of this assembly.
            mvcBuilder.AddApplicationPart(typeof(ServicesCollectionExtensions).Assembly);

            return mvcBuilder;
        }
    }
}
