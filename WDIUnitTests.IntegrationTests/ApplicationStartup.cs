using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace WDIUnitTests.IntegrationTests
{
    public class ApplicationStartup
    {
        [Fact]
        public async Task HelloWorldTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
            });

            var client = application.CreateClient();

            var response = await client.GetAsync("WeatherForecast");
            var responseContent = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            //...
        }
    }
}

