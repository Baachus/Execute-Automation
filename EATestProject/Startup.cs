using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestProject.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace EATestProject;

internal class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.UseWebDriverInitalizer();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();
    }
}
