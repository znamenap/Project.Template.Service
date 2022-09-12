using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using NUnit.Framework;

using System.Collections.Generic;

namespace Acme.Contoso.ServiceClient.SystemTests
{
    [TestFixture]
    public class ContosoServiceClientServiceExtensionsTests
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
        public void GivenValidConfiguration_WhenAddContosoServiceClient_ThenSuccessInstance()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{ContosoServiceClientOptions.Name}:{nameof(ContosoServiceClientOptions.ServiceUri)}", "https://localhost:40443/"),
                new KeyValuePair<string, string>($"{ContosoServiceClientOptions.Name}:{nameof(ContosoServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddContosoServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var ContosoServiceClient = serviceProvider.GetRequiredService<IContosoServiceClient>();
            Assert.That(ContosoServiceClient, Is.Not.Null);
            Assert.That(ContosoServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidConfiguration_WhenAddContosoServiceClient_ThenThrows()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{ContosoServiceClientOptions.Name}:{nameof(ContosoServiceClientOptions.ServiceUri)}", "https:/localhost:40443/"),
                new KeyValuePair<string, string>($"{ContosoServiceClientOptions.Name}:{nameof(ContosoServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddContosoServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<IContosoServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }

        [Test]
        public void GivenValidOptions_WhenAddContosoServiceClient_ThenSuccessInstance()
        {
            services.AddContosoServiceClient(options =>
            {
                options.ServiceUri = "https://localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var ContosoServiceClient = serviceProvider.GetRequiredService<IContosoServiceClient>();
            Assert.That(ContosoServiceClient, Is.Not.Null);
            Assert.That(ContosoServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidOptions_WhenAddContosoServiceClient_ThenThrows()
        {
            services.AddContosoServiceClient(options =>
            {
                options.ServiceUri = "https:/localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<IContosoServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }
    }
}
