using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotaDasTapas.Integration.Tests.Helpers;
using RotaDasTapas.Models.Request;

namespace RotaDasTapas.Integration.Tests
{
    [TestClass]
    public class RotaDasTapasTests : IDisposable
    {
        private const string RotasBaseUrl = "/api/v1/RotaDasTapas/Tapas?";
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _customWebApplicationFactory;

        public RotaDasTapasTests()
        {
            _customWebApplicationFactory = new CustomWebApplicationFactory<Startup>();
            _client = _customWebApplicationFactory.CreateClient();
        }
        
        public void Dispose()
        {
            _customWebApplicationFactory.Dispose();
            _client.Dispose();
        }

        [TestMethod]
        public async Task TestTapasEndpoint()
        {
            // Arrange
            var parameters = new TapasParameters
            {
                Localtime = "2020-06-11 18:16:59.851553"
            };
            
            var partialUrlWithParameters = await UrlUtils.BuildUrlWithParameters(parameters);
            var request = RotasBaseUrl + partialUrlWithParameters;

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task TestJourneyEndpoint()
        {
            // Arrange
            var parameters = new JourneyParameters
            {
                ListSelectedTapas = "Lisbon_4|Lisbon_2|Lisbon_3|Lisbon_6",
                Localtime = "2020-06-11 18:16:59.851553",
                City = "Lisbon"
            };
            
            var partialUrlWithParameters = await UrlUtils.BuildUrlWithParameters(parameters);
            var request = RotasBaseUrl + partialUrlWithParameters;
            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}