using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UserManager;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration(
                (hostContext, config) =>
                {
                    var env = hostContext.HostingEnvironment;

                    config
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile(
                            $"appsettings.{env.EnvironmentName}.json",
                            optional: true,
                            reloadOnChange: true
                        )
                        .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();
                }
            );
}

