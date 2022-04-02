using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.Repository
{
    public class MemoryDataRepository<TModel> : IDataRepository<TModel>
        where TModel : DataModel
    {
        protected readonly List<TModel> _items;
        public MemoryDataRepository()
        {
            _items = new List<TModel>();
        }

        public Task AddAsync(TModel model)
        {
            _items.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Task.FromResult(_items.AsEnumerable());
        }

        public Task<TModel?> GetByIdAsync(string id)
        {
            return Task.FromResult(_items.LastOrDefault(x => x.Id == id));
        }
    }
}
