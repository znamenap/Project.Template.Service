using FluentAssertions;

using NUnit.Framework;

using Project.Template.ServiceClient.Gateways;

using Refit;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.Template.ServiceClient.UnitTests
{
    public class AbstractGatewayBaseTests
    {
        internal class SystemUnderTest : AbstractClientGateway
        {
            internal Task<int> MakeFailureCall()
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                var settings = new RefitSettings();
                return ProcessResponse("FailCall",
                    new Func<Task<IApiResponse<int>>>(
                        () => Task.FromResult((IApiResponse<int>)new ApiResponse<int>(response, 0, settings))));
            }

            internal Task<int> MakeSuccessCall()
            {
                var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                var settings = new RefitSettings();
                return ProcessResponse("SuccessCall",
                    new Func<Task<IApiResponse<int>>>(
                        () => Task.FromResult((IApiResponse<int>)new ApiResponse<int>(response, 0, settings))));
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenGateway_WhenCallFailure_ThenThrowsTeamplateServiceException()
        {
            var sut = new SystemUnderTest();
            sut.Invoking(x => x.MakeFailureCall()).Should().ThrowAsync<TemplateServiceClientException>();
        }

        [Test]
        public async Task GivenGateway_WhenCallSuccess_ThenSuccessResponse()
        {
            var sut = new SystemUnderTest();
            var actual = await sut.MakeSuccessCall();
            actual.Should().Be(0);
        }
    }
}