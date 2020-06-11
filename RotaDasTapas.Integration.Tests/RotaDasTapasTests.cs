using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotaDasTapas.Integration.Tests
{
    [TestClass]
    public class RotaDasTapasTests
    {
        private readonly HttpClient Client;
        public RotaDasTapasTests()
        {
            Client = new TestFixture<Startup>().Client;
        }
        
        [TestMethod]
        public async Task TestTapasEndpoint()
        {
            // Arrange
            var request = "api/v1/RotaDasTapas/Tapas?localtime=2020-06-11 18:16:59.851553";

                // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        
        [TestMethod]
        public async Task TestJourneyEndpoint()
        {
            // Arrange
            var request = "api/v1/RotaDasTapas/Journey?listSelectedTapas=Lisbon_4|Lisbon_2|Lisbon_3|Lisbon_6&localtime=2020-06-10 17:19:32.693043&City=Lisbon";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}