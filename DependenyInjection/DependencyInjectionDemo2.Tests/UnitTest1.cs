using System;
using Xunit;
using DependencyInjectionDemo2;
using Moq;

namespace DependencyInjectionDemo2.Tests
{
    public class ClientTest
    {
        [Fact]
        public void InitiateServiceMethod_NoConditions_ProperMethodsCalled()
        {
            var serviceMock = new Mock<IService>();

            var client = new Client
            {
                Service = serviceMock.Object
            };

            client.InitiateServiceMethod();

            serviceMock.Verify(x => x.ServiceMethod());
        }
    }
}
