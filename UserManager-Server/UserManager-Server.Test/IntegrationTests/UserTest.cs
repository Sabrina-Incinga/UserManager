using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UserManager.DataAccess.Services;
using UserManager.Test.Helpers;
using Xunit;

namespace UserManager.Test.IntegrationTests;

[Collection(nameof(AppFactory))]
public class UserTest : IClassFixture<AppFactory>
{
    private readonly AppFactory _appFactory;
    public UserTest(AppFactory appFactory)
    {
        _appFactory = appFactory;
    }

    [Fact]
    public async Task GetActiveUsers_Test()
    {
        using (var scope = _appFactory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var unitOfWork = scopedServices.GetRequiredService<IUMUnitOfWork>();
            Utilities.InitializeUser(unitOfWork);
        }

        var client = _appFactory.CreateClient();

        var response = await client.GetAsync("api/User");
        var jsonObject = await response.Content.ReadFromJsonAsync<JsonArray>();

        Assert.Equal(2, jsonObject.Count);
    }
}