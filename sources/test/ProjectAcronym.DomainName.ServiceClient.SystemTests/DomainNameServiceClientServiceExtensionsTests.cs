using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using NUnit.Framework;

using System.Collections.Generic;

namespace ProjectAcronym.DomainName.ServiceClient.SystemTests
{
    [TestFixture]
    public class DomainNameServiceClientServiceExtensionsTests
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
        public void GivenValidConfiguration_WhenAddDomainNameServiceClient_ThenSuccessInstance()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{DomainNameServiceClientOptions.Name}:{nameof(DomainNameServiceClientOptions.ServiceUri)}", "https://localhost:40443/"),
                new KeyValuePair<string, string>($"{DomainNameServiceClientOptions.Name}:{nameof(DomainNameServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddDomainNameServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var DomainNameServiceClient = serviceProvider.GetRequiredService<IDomainNameServiceClient>();
            Assert.That(DomainNameServiceClient, Is.Not.Null);
            Assert.That(DomainNameServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidConfiguration_WhenAddDomainNameServiceClient_ThenThrows()
        {
            configuraiton.AddInMemoryCollection(new KeyValuePair<string, string>[] {
                new KeyValuePair<string, string>($"{DomainNameServiceClientOptions.Name}:{nameof(DomainNameServiceClientOptions.ServiceUri)}", "https:/localhost:40443/"),
                new KeyValuePair<string, string>($"{DomainNameServiceClientOptions.Name}:{nameof(DomainNameServiceClientOptions.TimeoutSeconds)}", "10"),
            });
            services.AddDomainNameServiceClient();
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<IDomainNameServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }

        [Test]
        public void GivenValidOptions_WhenAddDomainNameServiceClient_ThenSuccessInstance()
        {
            services.AddDomainNameServiceClient(options =>
            {
                options.ServiceUri = "https://localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var DomainNameServiceClient = serviceProvider.GetRequiredService<IDomainNameServiceClient>();
            Assert.That(DomainNameServiceClient, Is.Not.Null);
            Assert.That(DomainNameServiceClient.Administration, Is.Not.Null);
        }

        [Test]
        public void GivenInvalidOptions_WhenAddDomainNameServiceClient_ThenThrows()
        {
            services.AddDomainNameServiceClient(options =>
            {
                options.ServiceUri = "https:/localhost:40443/";
                options.TimeoutSeconds = 10;
            });
            var serviceProvider = services.BuildServiceProvider();

            var actual = Assert.Throws<OptionsValidationException>(() => serviceProvider.GetRequiredService<IDomainNameServiceClient>());
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Message, Contains.Substring("Invalid URI"));
        }
    }
}
