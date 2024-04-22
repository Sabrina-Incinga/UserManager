using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManager.DataAccess;

public static class MigrationConfig
{
    public static void RunMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<UserManagerContext>();
            
            context.Database.Migrate();
        }
    }
}
public static class ServiceConfigurator
{
}

