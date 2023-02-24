using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductAPI;

namespace EAIntegrationTest;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly WebApplicationFactory<Startup> webApplicationFactory;

    public UnitTest1(WebApplicationFactory<Startup> webApplicationFactory) 
    {
        this.webApplicationFactory = webApplicationFactory;
    }

    ///// <summary>
    ///// Problem with this approach is:
    ///// 1. You need to have application running
    ///// 2. Hardcoded request / path
    ///// 3. Very hard to maintain
    ///// 4. Classical approach
    ///// </summary>
    //[Fact]
    //public void TestWithHTTPClient()
    //{
    //    var client = new HttpClient();
    //    client.BaseAddress = new Uri("http://localhost:5010/");

    //    var response = client.Send(new HttpRequestMessage(HttpMethod.Get, "Product/GetProducts"));

    //    //TODO: This reads all values and can be tested against if wanted when JSON converted.
    //    //response.Content.ReadAsStringAsync().Result; 

    //    response.EnsureSuccessStatusCode();
    //}

    [Fact]
    public async Task TestWithWebAppFactory()
    {
        var webClient = webApplicationFactory.CreateClient();

        var product = await webClient.GetAsync("/Product/GetProducts");

        var result = product.Content.ReadAsStringAsync().Result;

        result.Should().Contain("Keyboard");
    }

    [Fact]
    public async Task TestWithGeneratorCode()
    {
        var webClient = webApplicationFactory.CreateClient();

        var product = new ProductAPI("https://localhost:44334", webClient);

        var results = await product.GetProductsAsync();

        results.Should().HaveCount(4);

        results.Select(x => x.Name == "Keyboard").Should().NotBeEmpty();
    }
}