using ProductAPI.Repository;

namespace EATestBDD.StepDefinitions;

[Binding]
public class ReusableSteps
{
    private readonly ScenarioContext scenarioContext;
    private readonly IProductRepository productRepository;

    public ReusableSteps(ScenarioContext scenarioContext, IProductRepository productRepository)
    {
        this.scenarioContext = scenarioContext;
        this.productRepository = productRepository;
    }

    [Then(@"I delete the product (.*) for cleanup")]
    public void ThenIDeleteTheProductHeadphonesForCleanup(string productName)
    {
        productRepository.DeleteProduct(productName);
    }

    [Given(@"I ensure the following product is created")]
    public void GivenIEnsureTheFollowingProductIsCreated(Table table)
    {
        //Automatically map all the Specflow table row data to the actual Product Type
        //based upon the property name to table row name.
        Product product = table.CreateInstance<Product>();

        productRepository.AddProduct(product);

        //Store the product details in the scenario context
        scenarioContext.Set<Product>(product);
    }

    [Given(@"I cleanup the following data")]
    public void GivenICleanupTheFollowingData(Table table)
    {
        var products = table.CreateSet<Product>();
        foreach (var product in products)
        {
            var prod = productRepository.GetProductByName(product.Name);

            if (prod != null)
                productRepository.DeleteProduct(product.Name);
        }
    }

}
