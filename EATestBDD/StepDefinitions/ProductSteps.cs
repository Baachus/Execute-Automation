using ProductAPI.Repository;

namespace EATestBDD.StepDefinitions;

[Binding]
public sealed class ProductSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IHomePage homePage;
    private readonly IProductPage productPage;
    private readonly IProductRepository productRepository;

    public ProductSteps
        (ScenarioContext scenarioContext,
        IHomePage homePage,
        IProductPage productPage,
        IProductRepository productRepository)
    {
        this.scenarioContext = scenarioContext;
        this.homePage = homePage;
        this.productPage = productPage;
        this.productRepository = productRepository;
    }

    [Given(@"I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
        homePage.ClickProduct();
    }

    [Given(@"I click the ""([^""]*)"" link")]
    public void GivenIClickTheLink(string linkName)
    {
        switch (linkName.ToLower())
        {
            case "create new":
            case "create":
                homePage.ClickCreate();
                break;
        }
    }

    [Given(@"I create a product with the following details")]
    public void GivenICreateAProductWithTheFollowingDetails(Table table)
    {
        //Automatically map all the Specflow table row data to the actual Product Type
        //based upon the property name to table row name.
        Product product = table.CreateInstance<Product>();
        productPage.EnterProductDetails(product);

        //Store the product details in the scenario context
        scenarioContext.Set<Product>(product);
    }

    [When(@"I click the (.*) link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct(string operation)
    {
        var product = scenarioContext.Get<Product>();
        homePage.PerformClickOnSpecialValue(product.Name, operation);
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        var product = scenarioContext.Get<Product>();

        Product actualProduct = productPage.GetProductDetails();
        actualProduct.Should().BeEquivalentTo(product,
            options => options.Excluding(x => x.Id));
    }

    [When(@"I edit the product details with the following")]
    public void WhenIEditTheProductDetailsWithTheFollowing(Table table)
    {
        var product = table.CreateInstance<Product>();

        productPage.EditProductDetails(product);
        //Store the product details in the scenario context
        scenarioContext.Set<Product>(product);
    }

}