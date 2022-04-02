using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WDIUnitTests.DatabaseLayer;

namespace WDIUnitTests.IntegrationTests.Fixtures
{
    public class AppFixture<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Tests");
            builder.ConfigureServices(services =>
            {
                OverrideDbWithInMemoryDb<TStartup>(services);
            });
        }

        public static IServiceCollection OverrideDbWithInMemoryDb<TStartup>(IServiceCollection services)
      where TStartup : class
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<WDIDbContext>));

            services.Remove(descriptor);

            services.AddDbContextPool<WDIDbContext>(options =>
            {
                options.UseInMemoryDatabase("WdiDB");
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<WDIDbContext>();
           
            try
            {
                InitializeDbForTests(db);
            }
            catch (Exception ex)
            {
              
                throw ex;
            }

            return services;
        }

        public static void InitializeDbForTests(WDIDbContext dataContext)
        {
            dataContext.Orders.Add(new DatabaseLayer.Data.Order("1", 15, true));
            dataContext.Orders.Add(new DatabaseLayer.Data.Order("2", 22, true));
            dataContext.Orders.Add(new DatabaseLayer.Data.Order("3", 33, false));

            dataContext.BlogPosts.Add(new DatabaseLayer.Data.BlogPost("5", "Test1", "Content1"));
            dataContext.BlogPosts.Add(new DatabaseLayer.Data.BlogPost("6", "Test2", "Content2"));
            dataContext.BlogPosts.Add(new DatabaseLayer.Data.BlogPost("7", "Test7", "Content7"));
            dataContext.BlogPosts.Add(new DatabaseLayer.Data.BlogPost("8", "Test8", "Content8"));

            dataContext.SaveChangesAsync().Wait();
        }
    }
}
