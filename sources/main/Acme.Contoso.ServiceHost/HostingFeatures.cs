using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Acme.Contoso.Services;

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Acme.Contoso.ServiceHost
{
    /// <summary>
    /// The template application features.
    /// </summary>
    public static class HostingFeatures
    {
        /// <summary>
        /// Sets up the web application builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="urls">The URL where to listen to requests.</param>
        /// <returns>A WebApplicationBuilder.</returns>
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder, params string[] urls)
        {
            ArgumentNullException.ThrowIfNull(builder, nameof(builder));

            var typeConfig = new TypeAdapterConfig();

            // Logging
            builder.Logging.AddConsole();

            // Add services to the container.
            builder.Services.AddSingleton(typeConfig);
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddControllers(o => SetMvcOptions(o)).AddControllers();
            builder.Services.AddServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>().CreateLogger("SwaggerGen");
                var dirEnumOptions = new EnumerationOptions {
                    IgnoreInaccessible = true,
                    RecurseSubdirectories = true
                };
                var location = Directory.GetParent(Assembly.GetExecutingAssembly().Location);
                logger.LogInformation("Observing {location} for additional Swagger documentation files.", location);
                var docs = location
                    .EnumerateFiles("*.xml", dirEnumOptions)
                    .ToList();
                docs.ForEach(x =>
                {
                    logger.LogInformation("Adding documentation from {FullName}", x.FullName);
                    options.IncludeXmlComments(x.FullName, true);
                });
            });

            if (urls.Length > 0)
            {
                builder.WebHost.UseUrls(urls);
            }

            return builder;
        }

        /// <summary>
        /// Sets the controller's MVC options.
        /// </summary>
        public static void SetMvcOptions(MvcOptions options)
        {
            // respect the browsers/clients Accept-Content request header
            options.RespectBrowserAcceptHeader = true;

            // Clients can request a particular format as part of the URL
            options.Filters.Add<FormatFilter>();

            // We want to preserve the SystemJsonOutputFormatter to take the default precedence over XML format.
            // We remove the type so it gets appended and used as the last order so JSON takes precedence.
            options.OutputFormatters.RemoveType<XmlDataContractSerializerOutputFormatter>();
            options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            options.OutputFormatters.RemoveType<XmlSerializerOutputFormatter>();
            options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            // We want to support the input XML format also.
            // We remove the type so it gets appended and used as the last order so JSON takes precedence.
            options.InputFormatters.RemoveType<XmlDataContractSerializerInputFormatter>();
            options.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(options));
            options.InputFormatters.RemoveType<XmlSerializerInputFormatter>();
            options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
        }

        /// <summary>
        /// Adds the template controllers.
        /// </summary>
        public static IMvcBuilder AddControllers(this IMvcBuilder builder)
        {
            // Register all controllers of this assembly.
            builder.AddApplicationPart(typeof(ServicesCollectionExtensions).Assembly);

            // Add support for Data Contracts and XML so the Accept-Content header can support it.
            builder.AddXmlSerializerFormatters();
            builder.AddXmlDataContractSerializerFormatters();

            return builder;
        }

        /// <summary>
        /// Adds the middleware.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <returns>The app.</returns>
        public static WebApplication AddMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseHttpLogging();
            app.MapControllers();

            return app;
        }
    }
}