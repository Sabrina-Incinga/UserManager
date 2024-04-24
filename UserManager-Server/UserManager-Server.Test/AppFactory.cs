using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManager.DataAccess;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace UserManager.Test;

public class AppFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        base.ConfigureWebHost(builder);


        builder.ConfigureServices(services =>
        {
            var servicesToReplace = new List<ServiceDescriptor?>()
            {
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UserManagerContext>)),
                services.SingleOrDefault(d => d.ServiceType == typeof(UserManagerContext))
            };

            foreach (var service in servicesToReplace)
            {
                if (service != null) services.Remove(service);
            }

            services.AddEntityFrameworkInMemoryDatabase();
            services.AddTransient(sp => new DbContextOptionsBuilder<UserManagerContext>().UseInMemoryDatabase("UserManagerTest").UseInternalServiceProvider(sp).Options);
            services.AddDbContext<UserManagerContext>(options => options.UseInMemoryDatabase(databaseName: "UserManagerTest"));
        });
    }

    protected override IHostBuilder? CreateHostBuilder()
    {
        var hostBuilder = base.CreateHostBuilder();

        hostBuilder?.UseEnvironment("Testing");

        return hostBuilder;
    }
}
