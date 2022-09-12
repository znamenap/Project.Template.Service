using FluentAssertions;

using Microsoft.AspNetCore.Mvc.Testing;

using NUnit.Framework;

using Acme.Contoso.ServiceHost;

using System.Threading.Tasks;

namespace Acme.Contoso.ServiceClient.SystemTests
{
    [TestFixture]
    public class AdministrationTests
    {
        private WebApplicationFactory<Program> app;
        private ContosoServiceClient sut;

        [OneTimeSetUp]
        public void Setup()
        {
            // TODO: Consider inspiration from https://github.com/martincostello/dotnet-minimal-api-integration-testing/tree/main/tests/TodoApp.Tests
            app = new WebApplicationFactory<Program>();
            sut = new ContosoServiceClient(app.Server.CreateHttpClientFactory());
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            sut.Dispose();
            if (app != null)
            {
                await app.DisposeAsync();
            }
        }

        [Test]
        public async Task GivenSupportsAdministration_WhenPing_ThenValidResponse()
        {
            var actual = await sut.Administration.Ping();
            actual.Should().NotBeNull();
        }

        [Test]
        public async Task GivenSupportsAdministration_WhenVersion_ThenValidResponse()
        {
            var actual = await sut.Administration.Version();
            actual.Should().NotBeNull();
        }

        [Test]
        public async Task GivenSupportsAdministration_WhenRoutes_ThenValidResponse()
        {
            var actual = await sut.Administration.Routes();
            actual.Should().NotBeNull();
        }

        [Test]
        public Task GivenSupportsAdministration_WhenReconfigure_ThenValidResponse()
        {
            return sut.Administration.Reconfigure();
        }
    }
}