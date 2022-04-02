using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.Clients
{
    public interface ISalesApiClient
    {
        Task<int> GetItemsCountAsync(CancellationToken ct);

        Task<bool> UpdateAsync(Order orderToUpdate);
    }
}
