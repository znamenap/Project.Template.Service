using FluentAssertions;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

using NUnit.Framework;

using System;

namespace ProjectAcronym.DomainName.ServiceClient.UnitTests
{
    [TestFixture]
    public class DomainNameServiceClientExceptionTests
    {
        [Test]
        public void TestParameterLessConstructor()
        {
            new DomainNameServiceClientException();
        }

        [Test]
        public void TestConstructorWithValidMessageParameter()
        {
            var sut = new DomainNameServiceClientException("message");

            sut.Message.Should().Be("message");
        }

        [Test]
        public void TestConstructorWithValidMessageAndExceptionParameter()
        {
            var sut = new DomainNameServiceClientException("message", new Exception());

            sut.Message.Should().Be("message");
            sut.InnerException.Should().BeAssignableTo<Exception>();
        }

        [TestCase(null, TestName = "TestConstructorWithInvalidMessage_NullMessage")]
        [TestCase("", TestName = "TestConstructorWithInvalidMessage_EmptyMessage")]
        public void TestConstructorWithInvalidMessage(string input)
        {
            FluentActions.Invoking(() => new DomainNameServiceClientException(input)).Should().Throw<ArgumentException>();
        }

        private readonly static TestCaseData[] TestConstructorWithInvalidMessageAndExceptionCombinations = new TestCaseData[] {
            new TestCaseData(null, null).SetName("TestConstructorWithInvalidMessageAndException_NullMessageAndNullInnerException"),
            new TestCaseData("", null).SetName("TestConstructorWithInvalidMessageAndException_EmptyMessageAndNullInnerException"),
            new TestCaseData("", new Exception()).SetName("TestConstructorWithInvalidMessageAndException_EmptyMessageAndNotNullInnerException")
        };

        [TestCaseSource(nameof(TestConstructorWithInvalidMessageAndExceptionCombinations))]
        public void TestConstructorWithInvalidMessageAndException(string input, Exception innerException)
        {
            FluentActions.Invoking(() => new DomainNameServiceClientException(input, innerException)).Should().Throw<ArgumentException>();
        }
    }
}
