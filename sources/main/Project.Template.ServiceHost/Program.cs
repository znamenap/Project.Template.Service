using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var builder = WebApplication.CreateBuilder(args);

            var typeConfig = new TypeAdapterConfig();

            // Add services to the container.
            builder.Services.AddSingleton(typeConfig);
            builder.Services.AddScoped<IMapper, Mapper>();
            builder.Services.AddLogging();
            builder.Services.AddControllers().AddTemplateControllers();
            builder.Services.AddTemplateServices();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                Directory
                    .EnumerateFiles(AppContext.BaseDirectory, "*.xml", new EnumerationOptions { IgnoreInaccessible = true, RecurseSubdirectories = true })
                    .ToList()
                    .ForEach(x => options.IncludeXmlComments(x, true));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
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