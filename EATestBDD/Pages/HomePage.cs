namespace EATestBDD.Pages;

public interface IHomePage
{
    void ClickProduct();
    void ClickCreate();
    void PerformClickOnSpecialValue(string name, string operation = "Details");
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;

    public HomePage(IDriverFixture driver) => this.driver = driver.Driver;

    IWebElement lnkProduct => driver.FindElement(By.LinkText("Product List"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));
    IWebElement tblList => driver.FindElement(By.CssSelector(".table"));

    public void ClickProduct() => lnkProduct.Click();

    public void ClickCreate() => lnkCreate.Click();

    public void PerformClickOnSpecialValue(string name, string operation = "Details")
    {
        tblList.PerformActionOnCell("5", "Name", name, operation);
    }
}
