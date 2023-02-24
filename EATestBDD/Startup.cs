using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Repository;
using SolidToken.SpecFlow.DependencyInjection;

namespace EATestBDD;

public static class Startup
{

    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        string projectPath = AppDomain.CurrentDomain.BaseDirectory
                                    .Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];

        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();

        string connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ProductDbContext>(options => options.UseSqlServer(connectionString));
        services.AddTransient<IProductRepository, ProductRepository>();

        services.UseWebDriverInitalizer();
        services.AddScoped<IHomePage, HomePage>();
        services.AddScoped<IProductPage, ProductPage>();
        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();

        return services;
    }
}
