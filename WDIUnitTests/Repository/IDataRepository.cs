using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.Repository
{
    public interface IDataRepository<TModel> where TModel : DataModel
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel?> GetByIdAsync(string id);

        Task AddAsync(TModel model);
    }
}
