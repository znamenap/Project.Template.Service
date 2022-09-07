using Microsoft.AspNetCore.TestHost;

using System;
using System.Net.Http;

namespace ProjectAcronym.DomainName.ServiceClient.SystemTests
{
    public static class TestServerExtensions
    {
        internal class TestServerHttpClientFactory : IHttpClientFactory
        {
            TestServer testServer;

            internal TestServerHttpClientFactory(TestServer testServer)
            {
                this.testServer = testServer ?? throw new ArgumentNullException(nameof(testServer));
            }

            /// <inheritdoc />
            public HttpClient CreateClient(string name)
            {
                return testServer.CreateClient();
            }
        }

        public static IHttpClientFactory CreateHttpClientFactory(this TestServer testServer)
        {
            return new TestServerHttpClientFactory(testServer);
        }
    }
}