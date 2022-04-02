using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.Repository
{
    public class EFDataRepository<TModel> : IDataRepository<TModel> where TModel : DataModel
    {
        private readonly WDIDbContext _wdiDbContext;
        public EFDataRepository(WDIDbContext wdiDbContext)
        {
            _wdiDbContext = wdiDbContext;
        }

        public Task AddAsync(TModel model)
        {
            _wdiDbContext.Add(model);
            _wdiDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            return Task.FromResult(_wdiDbContext.Set<TModel>().AsEnumerable());
        }

        public Task<TModel?> GetByIdAsync(string id)
        {
            return Task.FromResult(_wdiDbContext.Set<TModel>().FirstOrDefault(x => x.Id == id));
        }
    }
}
