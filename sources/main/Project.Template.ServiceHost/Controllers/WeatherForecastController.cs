using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Project.Template.ServiceContracts.AdminFeature;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Template.ServiceHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase, ITemplateAdmin
    {
        private readonly static string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AdminController> logger;

        public AdminController(ILogger<AdminController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("weather-forecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            logger.LogInformation("Processing weather forecast request.");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("version")]
        public ApplicationVersionDto GetApplicationVersion()
        {
            logger.LogInformation("Processing application version request.");
            return new ApplicationVersionDto();
        }

        [HttpGet("ping")]
        public PongDto Ping()
        {
            logger.LogInformation("Processing ping request.");
            return new PongDto();
        }

        [HttpPost("logging")]
        public void SetLoggingLevel(LogLevel logLevel)
        {

        }
    }
}