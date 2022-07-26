using FluentAssertions;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

using NUnit.Framework;

using System;

namespace Project.Template.ServiceClient.UnitTests
{
    [TestFixture]
    public class TemplateServiceClientExceptionTests
    {
        [Test]
        public void TestParameterLessConstructor()
        {
            new TemplateServiceClientException();
        }

        [Test]
        public void TestConstructorWithValidMessageParameter()
        {
            var sut = new TemplateServiceClientException("message");

            sut.Message.Should().Be("message");
        }

        [Test]
        public void TestConstructorWithValidMessageAndExceptionParameter()
        {
            var sut = new TemplateServiceClientException("message", new Exception());

            sut.Message.Should().Be("message");
            sut.InnerException.Should().BeAssignableTo<Exception>();
        }

        [TestCase(null, TestName = "TestConstructorWithInvalidMessage_NullMessage")]
        [TestCase("", TestName = "TestConstructorWithInvalidMessage_EmptyMessage")]
        public void TestConstructorWithInvalidMessage(string input)
        {
            FluentActions.Invoking(() => new TemplateServiceClientException(input)).Should().Throw<ArgumentException>();
        }

        private readonly static TestCaseData[] TestConstructorWithInvalidMessageAndExceptionCombinations = new TestCaseData[] {
            new TestCaseData(null, null).SetName("TestConstructorWithInvalidMessageAndException_NullMessageAndNullInnerException"),
            new TestCaseData("", null).SetName("TestConstructorWithInvalidMessageAndException_EmptyMessageAndNullInnerException"),
            new TestCaseData("", new Exception()).SetName("TestConstructorWithInvalidMessageAndException_EmptyMessageAndNotNullInnerException")
        };

        [TestCaseSource(nameof(TestConstructorWithInvalidMessageAndExceptionCombinations))]
        public void TestConstructorWithInvalidMessageAndException(string input, Exception innerException)
        {
            FluentActions.Invoking(() => new TemplateServiceClientException(input, innerException)).Should().Throw<ArgumentException>();
        }
    }
}
