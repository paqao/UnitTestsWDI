using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WDIUnitTests.Clients;

namespace WDIUnitTests.MSUnit
{
    [TestClass]
    public class SalesClientTests
    {
        private SalesApiClient _salesApiClient;
        private HttpClient _httpClient;
        private Mock<HttpMessageHandler> _httpMessageHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandler.Object);
            _salesApiClient = new SalesApiClient(_httpClient);
        }

        [TestMethod]
        public async Task TestThat_ProperRequestIsSent()
        {
            // Arrange
            string url = "http://localhost:1234";
            int number = 10;
            string json = JsonSerializer.Serialize(number, typeof(int));
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);


            // Act
            int result = await _salesApiClient.GetItemsCountAsync(CancellationToken.None);

            // Assert
          
        }
    }
}
