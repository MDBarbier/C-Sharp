using Moq;
using Xunit;
using DependenyInjectionDemo1;

namespace ClientServiceTest
{
    public class ClientServiceTest
    {
        [Fact]
        public void InitiateServiceMethod_NoConditions_Success()
        {
            var serviceMock = new Mock<IService>();

            var client = new Client(serviceMock.Object);
            client.InitiateServiceMethod();

            serviceMock.Verify(x => x.ServiceMethod());
        }
    }
}
