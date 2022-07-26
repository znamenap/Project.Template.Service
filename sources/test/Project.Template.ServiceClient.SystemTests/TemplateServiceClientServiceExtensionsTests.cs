using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using NUnit.Framework;

using System.Collections.Generic;

namespace Project.Template.ServiceClient.SystemTests
{
    [TestFixture]
    public class TemplateServiceClientServiceExtensionsTests
    {
        private IServiceCollection services;
        private ConfigurationManager configuraiton;

        [SetUp]
        public void SetUp()
        {
            services = new ServiceCollection();
            configuraiton = new ConfigurationManager();
            services.AddSingleton<IConfiguration>(configuraiton);
        }

        [TearDown]
        public void TearDown()
        {
            configuraiton?.Dispose();
        }

        [Test]
        public void GivenValidConfiguration_WhenAddTemplateServiceClient_ThenSuccessInstance()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{TemplateServiceClientOptions.Name}:{nameof(TemplateServiceClientOptions.ServiceUri)}", "https://localhost:40443/"),
                new KeyValuePair<string, string>($"{TemplateServiceClientOptions.Name}:{nameof(TemplateServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddTemplateServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var templateServiceClient = serviceProvider.GetRequiredService<ITemplateServiceClient>();
            Assert.That(templateServiceClient, Is.Not.Null);
            Assert.That(templateServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidConfiguration_WhenAddTemplateServiceClient_ThenThrows()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{TemplateServiceClientOptions.Name}:{nameof(TemplateServiceClientOptions.ServiceUri)}", "https:/localhost:40443/"),
                new KeyValuePair<string, string>($"{TemplateServiceClientOptions.Name}:{nameof(TemplateServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddTemplateServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<ITemplateServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }

        [Test]
        public void GivenValidOptions_WhenAddTemplateServiceClient_ThenSuccessInstance()
        {
            services.AddTemplateServiceClient(options =>
            {
                options.ServiceUri = "https://localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var templateServiceClient = serviceProvider.GetRequiredService<ITemplateServiceClient>();
            Assert.That(templateServiceClient, Is.Not.Null);
            Assert.That(templateServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidOptions_WhenAddTemplateServiceClient_ThenThrows()
        {
            services.AddTemplateServiceClient(options =>
            {
                options.ServiceUri = "https:/localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<ITemplateServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }
    }
}
