using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;
using WDIUnitTests.Repository;

namespace WDIUnitTests.XUnit.Fixtures
{
    public class BlogPostRepositoryFixture : IDisposable
    {
        public BlogPostRepositoryFixture()
        {
            Db = new MemoryDataRepository<BlogPost>();

            Db.AddAsync(new BlogPost("1", "Test", "dsadsadas"));
            Db.AddAsync(new BlogPost("2", "Test123", "dsadsadas"));
            Db.AddAsync(new BlogPost("3", "Test124", "dsadsadas"));
        }

        public void Dispose()
        {
        }

        public MemoryDataRepository<BlogPost> Db { get; private set; }
    }
}
