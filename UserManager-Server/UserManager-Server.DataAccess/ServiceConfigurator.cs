using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManager.DataAccess.Services;
using UserManager.DataAccess.Services.Repositories;
using UserManager.DataAccess.Services.Repositories.Factory;

namespace UserManager.DataAccess;

public static class MigrationConfig
{
    public static void RunMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<UserManagerContext>();

        if (!context.Database.IsInMemory())
            context.Database.Migrate();
    }
}
public static class ServiceConfigurator
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IUMUnitOfWork, UMUnitOfWork>();
        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}

