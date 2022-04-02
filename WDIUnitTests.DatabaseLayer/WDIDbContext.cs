using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDIUnitTests.DatabaseLayer.Data;

namespace WDIUnitTests.DatabaseLayer
{
    public class WDIDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public WDIDbContext(DbContextOptions<WDIDbContext> context) : base(context)
        {

        }
    }
}
