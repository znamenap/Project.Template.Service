using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Project.Template.Services;

using System;
using System.IO;
using System.Linq;

namespace Project.Template.ServiceHost
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = WebApplication
                .CreateBuilder()
                .SetupBuilder()
                .Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.UseHttpLogging();
            app.Run();
        }

        public static WebApplicationBuilder SetupBuilder(this WebApplicationBuilder builder)
        {
            var typeConfig = new TypeAdapterConfig();

            // Add services to the container.
            builder.Services.AddSingleton(typeConfig);
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddLogging();
            builder.Services.AddControllers(SetTemplateMvcOptions).AddTemplateControllers();
            builder.Services.AddTemplateServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var dirEnumOptions = new EnumerationOptions {
                    IgnoreInaccessible = true,
                    RecurseSubdirectories = true
                };
                Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml", dirEnumOptions)
                    .ToList()
                    .ForEach(x => options.IncludeXmlComments(x, true));
            });

            return builder;
        }

        /// <summary>
        /// Sets the controller's MVC options.
        /// </summary>
        public static void SetTemplateMvcOptions(MvcOptions options)
        {
            // respect the browsers/clients Accept-Content request header
            options.RespectBrowserAcceptHeader = true;
        }

        /// <summary>
        /// Adds the template controllers.
        /// </summary>
        public static IMvcBuilder AddTemplateControllers(this IMvcBuilder builder)
        {
            // Register all controllers of this assembly.
            builder.AddApplicationPart(typeof(ServicesCollectionExtensions).Assembly);

            // PascalCase formatting
            builder.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            // Add support for Data Contracts and Xml so the Accept-Content header can support it.
            builder.AddXmlSerializerFormatters();
            builder.AddXmlDataContractSerializerFormatters();

            return builder;
        }
    }
}