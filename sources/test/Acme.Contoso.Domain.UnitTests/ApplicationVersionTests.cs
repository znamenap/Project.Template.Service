using FluentAssertions;

using NUnit.Framework;

using Acme.Contoso.Domain.Administration;

namespace Acme.Contoso.Domain.UnitTests
{
    public class ApplicationVersionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreate_ThenSuccess()
        {
            var actual = ApplicationVersion.Create();

            actual.Should().NotBeNull();
        }

        [Test]
        public void WhenCompare_ThenSuccess()
        {
            var sut1 = ApplicationVersion.Create();
            var sut2 = ApplicationVersion.Create();
            var actual = sut1 == sut2;

            actual.Should().BeTrue();
        }

        [Test]
        public void WhenToString_ThenSuccess()
        {
            var sut = ApplicationVersion.Create();

            sut.ToString().Should().NotBeNull().And.Contain(typeof(ApplicationVersion).Assembly.GetName().Name);
        }
    }
}