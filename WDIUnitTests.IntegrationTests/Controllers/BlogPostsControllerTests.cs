using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.IntegrationTests.Fixtures;
using Xunit;

namespace WDIUnitTests.IntegrationTests.Controllers
{
    public partial class ControllersTests
    {
        [Fact]
        public async Task OrdersController_Should_Return_Items()
        {
            // Arrange
            var appClient = _appFixture.CreateClient();

            // Act
            var response = await appClient.GetAsync("orders");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task OrdersController_ShouldAddItemsToCollection()
        {
            // Arrange
            var appClient = _appFixture.CreateClient();
            var newBlogPost = new Order("1500", 1302.2f, true);

            // Act
            var response1 = await appClient.GetAsync("orders");
            var content = JsonSerializer.Serialize(newBlogPost);
            var response2 = await appClient.PostAsync("orders", new StringContent(content, Encoding.UTF8, mediaType: "application/json"));
            var response3 = await appClient.GetAsync("orders");

            // Assert
            response1.EnsureSuccessStatusCode();
            response2.EnsureSuccessStatusCode();
            response3.EnsureSuccessStatusCode();
            var response1Content = await response1.Content.ReadAsStringAsync();
            var response3Content = await response3.Content.ReadAsStringAsync();
            var items1 = JsonSerializer.Deserialize<List<Order>>(response1Content);
            var items3 = JsonSerializer.Deserialize<List<Order>>(response3Content);
            Assert.NotEqual(items1.Count, items3.Count);
        }
    }
}
