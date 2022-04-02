using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.Clients
{
    public class SalesApiClient : ISalesApiClient
    {
        private readonly HttpClient _httpClient;

        public SalesApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetItemsCountAsync(CancellationToken ct)
        {
            var response = await _httpClient.GetAsync("http://localhost:1234/orders/count", ct);
            return await response.Content.ReadFromJsonAsync<int>(); ;
        }

        public Task<bool> UpdateAsync(Order orderToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
